   M S B A M L   `   `   `  ����@  <дэ2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:дэ2дэ2  5   	       дэ2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:дэ2     5   	     � Title$  Главное окно��5   	   $	��500��6   $	��950��6+   .��5	      � ���	#FFD0C4C4 � RowDefinitions 5
   
   �� 5      $	��377 �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ SchoolChildNew��5         AutoGenerateColumns .     
IsReadOnly .    CanUserResizeColumns .  $��0,44,0,0q�6v      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО ребёнка��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 5   %   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   :   �� *Children.namee+5   %     5      $ ФИО родителя��6%   $	 160 6]   	 6;   �� *Parents.namee+6]     5      $! Номер родителя��6%   $	 160 6n   	 6=   �� *Parent_contacts.phone_number+6n     5      $, &Дата первого занятия��6%   $	 160 6y   	 6C   �� *#!Date_Of_Enrolment.enrollment_date+6y     5      $ Группа��6%   $	 160 6Z   	 65   �� *Activities.namee+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        GridTemplate��$
 auto 5   ?   
   CellTemplate
 5      �� 5      .R�5      ��  ��Name$ BtnEdit��6=   -   5        $ ��Редактировать��5   %   6N   5      5      5      �� 5    
   -   5        $��BtnAdd��5    L   $��Добавить��6   $��1��6$   $
��Left=�61   ���	#FFF7EBEB6o   �� 5!   
   -   5        $��BtnAutorization��5!   M   $��Вернуться��6   $��1��6%   $
��Left=�62   $��	487,0,0,0q�6�   ���	#FFF7EBEB6�   �� 5"   
   -   5        $��BtnUp��5"   L   $��Обновить��6   $��1��6$   $
��Left=�61   ���	#FFF7EBEB$��	213,0,0,0q�5#      �� 5$   
   -   5        $��BtnDelet��5$   L   $��Удалить��6   $��1��6#   $��Right=�60   ���	#FFF7EBEB5%      �� 5'   
   $��
Поиск��6   $
��Left=�6!   $��	29,10,0,0q�5(      $	��Top=�6   $��50��6,   �� 5)   
   -   5         ��Name$ 	SearchBox��5)      $	��200��6%   $��22��5*      $��79,8,0,0q�5+      $	��Top=�6   $
��Left=�6+   �� 5-   
   -	   5         ��Name$ ComboStatus��5-       �� DisplayMemberPath$ namee��6(   $��
378,12,0,0q�6B   $	��Top=�6V   $��23��5.      $
��Left=�6   $	��130��6(   �� 50   
   $��Фильтр��6   $
��Left=�6"   $��
328,12,0,0q�51      $	��Top=�6   $��50��6-   �� 53   
   -
   5        $��BtnOut��53   @   $��Применить��6   $
��Left=�6%   $��
520,10,0,0q�54      $	��Top=�6*   $��24��6B   $	��109��55      �� 56   
   $��795,10,55,337q�6   $��/11.jpg��6'   $	��100��68   $��30��6D   58      59      