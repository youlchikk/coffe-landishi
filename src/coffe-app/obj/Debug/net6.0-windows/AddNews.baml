   M S B A M L   `   `   `  ����D  @coffe-app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:coffe_app	coffe_app  5          coffe_app.AddNewsWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:coffe_app     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$%  Добавить новость��5       � Icon$ Resources/ico.ico��5	      $	��400��5
      $	��300��5      ���	#FFF3D9F2.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Заголовок:��6   �� 5   
   -   5        $��TitleTextBox��5      $��1��5      $��0,5,0,10q�5      �� 5   
   $��2��6   $��Описание:��6   �� 5   
   -   5        $��DescriptionTextBox��5      $��3��5      $��	0,5,0,-69q�5       �� 5"   
   $��4��5#      $��10q�5$      $��Center=�5%       �� Orientation$ 
Horizontal=�5&      �� 5'   
   -   5         ��Name$ 	AddButton��5(      $��3��5)      $��23,153,290,-117q�5*      ���	#FFF5ACFF���	#FFECB7FF$��Добавить��5.      $��Monotype Corsiva)�5/      $��16(�50      �� 51   
   -   5        $ CancelButton��52      $��3��53      $��304,153,23,-117q�54      ���	#FFF5ACFF���	#FFECB7FF$��Отмена��58      $��Monotype Corsiva)�59      $��16(�5:      5;      5<      