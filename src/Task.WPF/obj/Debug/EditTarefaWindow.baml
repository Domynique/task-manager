   M S B A M L   `   `   `  ����  Task.WPF    Task.WPF.EditTarefaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Editar Tarefa��5   	   $	��320��6   $	��400��6,   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Título:��6   $��0��6#   $��Center=�60   $��0,0,0,5q�6K   �� 5   
   -   5         ��Name$ TituloTextBox��5      $��1��6)   $	��300��66   $��25��6B   $��0,0,0,10q�6N   �� 5   
   $��Descrição:��6   $��2��6&   $��Center=�63   $��0,0,0,5q�6N   �� 5   
   -   5        $ DescricaoTextBox��5      $��3��6,   $	��300��69   $��60��6E   $��0,0,0,10q�6Q   �� 5   
   $��Status:��6   $��4��6#   $��Center=�60   $��0,0,0,5q�6K   �� 5   
   -   5         ��Name$ StatusComboBox��5      $��5��6+   $	��200��68   $��25��6D   $��
0,0,100,68q�6P    �� SelectedValuePath$ Content��6e   .@�5      �� $��Pendente��6   �� 5      $��EmProgresso��6   �� 5      $��	Concluida��6   5       �� 5"   
   $��Data de Conclusão:��6   $��Center=�6.   $��5��6I   �� 5#   
   -   5        $ DataConclusaoTextBox��5#      $��5��60   $	��200��6=   $��25��6I   $��0,62,100,20q�6U    �� 
IsReadOnly . 6j   �� 5&   
   -   5        $��Salvar��5&      $��5��6"   $��Right=�6D   $��30��6`   $��80��6l   5'      5(      