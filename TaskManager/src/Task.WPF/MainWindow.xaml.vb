Imports System.Net.Http
Imports System.Net.Http.Json
Imports Task.WPF.Models
Imports Task.WPF.ViewModel

Public Class MainWindow
    Private _httpClient As HttpClient
    Private _tarefas As List(Of TarefaViewModel)

    Public Sub New()
        InitializeComponent()
        Dim handler As New HttpClientHandler() With {
            .ServerCertificateCustomValidationCallback = Function(sender, cert, chain, sslPolicyErrors) True
        }
        _httpClient = New HttpClient(handler) With {
            .BaseAddress = New Uri("https://localhost:5001/")
        }
        CarregarTarefas()
    End Sub

    Public Property JsonConvert As Object

    Private Async Sub CarregarTarefas()
        Try
            Dim response = Await _httpClient.GetAsync("api/tarefa")
            response.EnsureSuccessStatusCode()

            _tarefas = Await response.Content.ReadFromJsonAsync(Of List(Of TarefaViewModel))()

            If _tarefas Is Nothing Then _tarefas = New List(Of TarefaViewModel)()
            If DataGridTarefas IsNot Nothing Then
                DataGridTarefas.ItemsSource = _tarefas
            End If
        Catch ex As Exception
            MessageBox.Show($"Erro ao carregar tarefas: {ex.Message}")
    End Try
    End Sub

    Private Async Sub AdicionarTarefa_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim tarefa = New TarefaViewModel() With {
                .Titulo = "Nova Tarefa",
                .Descricao = "Descrição da tarefa",
                .Status = Status.Pendente
            }
            Dim response = Await _httpClient.PostAsJsonAsync("api/tarefa", tarefa)
            If response.IsSuccessStatusCode Then
                CarregarTarefas()
            Else
                Dim errorContent = Await response.Content.ReadAsStringAsync()
                MessageBox.Show($"Erro ao adicionar tarefa: {errorContent}")
            End If
        Catch ex As Exception
            MessageBox.Show($"Erro ao adicionar tarefa: {ex.Message}")
        End Try
    End Sub

    Private Async Sub EditarTarefa_Click(sender As Object, e As RoutedEventArgs)
        Try
            If DataGridTarefas.SelectedItem IsNot Nothing AndAlso TypeOf DataGridTarefas.SelectedItem Is TarefaViewModel Then
                
                Dim tarefa = DirectCast(DataGridTarefas.SelectedItem, TarefaViewModel)
                Dim editWindow = New EditTarefaWindow(_httpClient,tarefa)
                
               
                Dim result? As Boolean = editWindow.ShowDialog()

                ' Verificar se o diálogo foi confirmado
                If result.HasValue AndAlso result.Value Then
                    ' Não precisa de novo envio, pois o envio foi feito na janela de edição
                    CarregarTarefas()
                End if
            Else
                MessageBox.Show("Selecione uma tarefa para editar.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Erro ao editar tarefa: {ex.Message}")
        End Try
    End Sub

    Private Async Sub ExcluirTarefa_Click(sender As Object, e As RoutedEventArgs)
        Try
            If DataGridTarefas.SelectedItem IsNot Nothing AndAlso TypeOf DataGridTarefas.SelectedItem Is TarefaViewModel Then
                Dim tarefa = DirectCast(DataGridTarefas.SelectedItem, TarefaViewModel)
                Dim response = Await _httpClient.DeleteAsync($"api/tarefa/{tarefa.Id}")
                If response.IsSuccessStatusCode Then
                    CarregarTarefas()
                Else
                    Dim errorContent = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show($"Erro ao excluir tarefa: {errorContent}")
                End If
            Else
                MessageBox.Show("Selecione uma tarefa para excluir.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Erro ao excluir tarefa: {ex.Message}")
        End Try
    End Sub

    Private Sub StatusComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If DataGridTarefas Is Nothing Then Return

        Dim selectedStatus = DirectCast(StatusComboBox.SelectedItem, ComboBoxItem).Content.ToString()
        If selectedStatus = "Todos" Then
            DataGridTarefas.ItemsSource = _tarefas
        Else
            DataGridTarefas.ItemsSource = _tarefas.FindAll(Function(t) t.Status.ToString() = selectedStatus)
        End If
    End Sub
End Class

