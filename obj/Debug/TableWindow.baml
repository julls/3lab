   M S B A M L   `   `   `  ����@  <дэ2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:дэ2дэ2  5   	       дэ2.TableWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:дэ2     5   	     � Title$  TableWindow��5      $	��650��6   $	��500��6)   .��5
      &   System.Windows.Controls.DataGrid  -   5          Name$ tableWindow��5
         AutoGenerateColumns .     
IsReadOnly .    CanUserResizeColumns .  $��0,44,0,0q�6o      Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Группа��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Activities.id+6S     5      $ Название��6!   $
 auto 6X    63   �� *Activities.namee+6X     5      $ День недели��6!   $
 auto 6V    66   �� *day_of_week+6V     5      $ Время начала��6!   $
 auto 6V    67   �� *
time_start+6V     5      $ Время конца��6!   $
 auto 6S    66   �� *
time_END+6S   5      5      