   M S B A M L   `   `   `  ����D  @coffe-app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:coffe_app	coffe_app  5          coffe_app.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:coffe_app     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Главное окно��5       � Icon$ Resources/ico.ico��5	      $	��800��5
      $	��450��5      ���	#FFF3D9F2.��5      � $��0,0,0,-6q�6    J� RenderTransformOrigin$ 0.501,0.499&�6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5        $��
ExitButton��5      $	��110��5      $��37��5      $��655,371,0,0q�5      $
��Left=�5      $	��Top=�5      ���	#FFF5ACFF���	#FFECB7FF$��
Выход��5      $��Monotype Corsiva)�5      $��20(�5      $ 0.503,0.503&�5      �� 5    
   -   5        $��
MenuButton��5!      $	��174��5"      $��33��5#      $��
21,125,0,0q�5$      $
��Left=�5%      $	��Top=�5&      ���	#FFF5ACFF���	#FFECB7FF$��Меню��5*      $��Monotype Corsiva)�5+      $��20(�5,      $ 0.503,0.503&�5-      �� 5.   
   -   5        $��DealsButton��5/      $	��174��50      $��33��51      $��
21,187,0,0q�52      $
��Left=�53      $	��Top=�54      ���	#FFF5ACFF���	#FFECB7FF$��
Акции��58      $��Monotype Corsiva)�59      $��20(�5:      $ 0.503,0.503&�5;      �� 5<   
   -   5        $��OrderButton��5=      $	��174��5>      $��34��5?      $��
21,253,0,0q�5@      $
��Left=�5A      $	��Top=�5B      ���	#FFF5ACFF���	#FFECB7FF$��Окно заказа��5F      $��Monotype Corsiva)�5G      $��20(�5H      $ 0.503,0.503&�5I      �� 5J   
   -   5        $��ProfileButton��5K      $	��174��5L      $��34��5M      $��	21,61,0,0q�5N      $
��Left=�5O      $	��Top=�5P      ���	#FFF5ACFF���	#FFECB7FF$��Мой профиль��5T      $��Monotype Corsiva)�5U      $��20(�5V      $ 0.503,0.503&�5W      �� 5X   
   -   5        $��
NewsButton��5Y      $	��174��5Z      $��34��5[      $��
21,317,0,0q�5\      $
��Left=�5]      $	��Top=�5^      ���	#FFF5ACFF���	#FFECB7FF$��Новости��5b      $��Monotype Corsiva)�5c      $��20(�5d      $ 0.499,0.531&�5e      �� 5f   
   -   5        $��GreetingLabel��5g      $	��196��5h      $��41��5i      $��
312,10,0,0q�5j      $
��Left=�5k      $	��Top=�5l      $%��Кофейня "Ландыши"��5m      $��Monotype Corsiva)�5n      $��22(�5o      �� 5r   
   -   5        $��AdminButtonsPanel��5s      $��
250,60,0,0q�5t      $
��Left=�5u      $	��Top=�5v      $y�	Collapsed=�5w      .+�5x      �� -	   5        $��StatusOrderButton��5y      $	��0,5q�5z      ���	#FFF5ACFF���	#FFECB7FF$4��.Изменение статуса заказа��5~      $��Monotype Corsiva)�5      $��20(�5�      �� 5�      -
   5        $��StatisticsButton��5�      $	��0,5q�5�      ���	#FFF5ACFF���	#FFECB7FF$��Статистика��5�      $��Monotype Corsiva)�5�      $��20(�5�      5�      5�      5�      