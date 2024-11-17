Imports System
Imports Task.WPF.Models


Namespace ViewModel
    Public Class TarefaViewModel
        Public Property Id As Guid
        Public Property Titulo As String
        Public Property Descricao As String
        Public Property DataDeCriacao As DateTime
        Public Property DataDeConclusao As DateTime?
        Public Property Status As Status
    End Class
End Namespace