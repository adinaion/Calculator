   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Calculator.ViewCalculator.View  5   	   '    !Calculator.View.MemoryStackWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Calculator.View     5   	     � Title$  Memory Stack��5   	   $	��300��5	   	   $	��300��5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���#A7D8E8.+�5   
   �� -   5        $��MemoryStackListBox��5      ���#A7D8E8$��16(�6A   $��10,40,10,10q�6O   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   ���#F1B6D1$��5q�6j   .+�5      �� $��Center=�65   $��10q�6P   ��6$   �� 6P   �� 5      $ 
Horizontal=�6%   $��Right=�6>   $��80,0,0,0q�6Z   .+�5      �� $��MC��6%   $��16(�62   $��30��6@   $��30��6K   $��5q�6W   ���#B8A0D4
���   ���6�   �� **(DataContext.RemoveFromMemoryStackCommand+ �� RelativeSource ��  �� AncestorType
 Window��6�   �� �� 5      $��M+��6%   $��16(�62   $��30��6@   $��30��6K   $��5q�6W   ���#B8A0D4
���   ���6�   �� *%#DataContext.AddToMemoryStackCommand+ �� 
 Window��6�   �� �� 5      $��M-��6%   $��16(�62   $��30��6@   $��30��6K   $��5q�6W   ���#B8A0D4
���   ���6�   �� *,*DataContext.SubtractFromMemoryStackCommand+ �� 
 Window��6�   �� 5      5      5      5      �� 5   
   -   5        $��Close��5      $��16(�6!   $��Bottom=�6/   $��Center=�6J   $��10q�6g   ���#B8A0D4
���   �6�   5      5       