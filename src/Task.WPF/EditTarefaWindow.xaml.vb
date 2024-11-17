Imports Task.WPF.ViewModel
Imports Task.WPF.Models
Imports System.Net.Http
Imports System.Net.Http.Json


Public Class EditTarefaWindow
    Private _httpClient As HttpClient
Private _tarefa As TarefaViewModel

    Public Sub New(httpClient As HttpClient,tarefa As TarefaViewModel)
        InitializeComponent()
        _httpClient = httpClient
        _tarefa = tarefa
        
        TituloTextBox.Text = tarefa.Titulo
        DescricaoTextBox.Text = tarefa.Descricao
        StatusComboBox.SelectedValue = tarefa.Status.ToString()
End Sub
    Private Sub StatusComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles StatusComboBox.SelectionChanged
        If StatusComboBox.SelectedValue.ToString() = "Concluida" Then
            _tarefa.DataDeConclusao = DateTime.Now
            DataConclusaoTextBox.Text = _tarefa.DataDeConclusao.Value.ToString("yyyy-MM-dd HH:mm:ss")
        Else
            _tarefa.DataDeConclusao = Nothing
            DataConclusaoTextBox.Text = String.Empty
        End If
    End Sub
    Private Async Sub Salvar_Click(sender As Object, e As RoutedEventArgs)
        Try
            _tarefa.Titulo = TituloTextBox.Text
            _tarefa.Descricao = DescricaoTextBox.Text
            _tarefa.Status = CType([Enum].Parse(GetType(Status), StatusComboBox.SelectedValue.ToString()), Status)

            If CType([Enum].Parse(GetType(Status), StatusComboBox.SelectedValue.ToString()), Status) = Status.Concluida Then
                _tarefa.DataDeConclusao = DateTime.Now
            End If

            Dim response = Await _httpClient.PutAsJsonAsync($"api/tarefa/{_tarefa.Id}", _tarefa)
            If response.IsSuccessStatusCode Then
                DialogResult = True
                Me.Close()
            Else
                Dim errorContent = Await response.Content.ReadAsStringAsync()
                MessageBox.Show($"Erro ao salvar tarefa: {errorContent}")
            End If
        Catch ex As Exception
            MessageBox.Show($"Erro ao salvar tarefa: {ex.Message}")
        End Try
    End Sub
End Class
