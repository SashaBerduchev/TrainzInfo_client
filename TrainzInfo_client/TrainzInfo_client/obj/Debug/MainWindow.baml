   M S B A M L   `   `   `  ����L  HTrainzInfo_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TrainzInfo_clientTrainzInfo_client  5   	   "    TrainzInfo_client.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TrainzInfo_client     5   	     � Title$  
MainWindow��5   	   $	��850��6   $
��1200��6)    � WindowState$ 	Maximized=�66   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ listinfo��5      $��1��6$   $��0��61   $��4��6A   $��3��6U   �� 5   
   -   5         ��Name$ btnLoad��5      $5��/Загрузка новостей с сайта��6"   $
��Left=�6F   $��	37,56,0,0q�6a   $	��Top=�6t   $	��120��6�   $��46��6�   �� 5   
   -   5        $ 
btnNewsAdd��5      $#��Создать новость��6%   $
��Left=�6?   $��
37,127,0,0q�6Z   $	��Top=�6n   $	��120��6�   $��46��6�   6�   �� 5   
   -   5        $ btnElectric_locomotives��5      $+��%Список электровозов��62   $
��Left=�6P   $��
209,56,0,0q�6k   $	��Top=�6   $	��120��6�   $��46��6�   $��2��6�   6�   �� 5   
   -   5        $ ElectrickLocomotiveAdd��5      $+��%Добавить электровоз��61   $
��Left=�6O   $��209,127,0,0q�6j   $	��Top=�6   $	��120��6�   $��46��6�   $��2��6�   6�   �� 5   
   -   5        $  btnDiesel_locomotives_Copy��5      $'��!Список тепловозов��65   $
��Left=�6Q   $��	60,56,0,0q�6l   $	��Top=�6   $	��120��6�   $��46��6�    J� RenderTransformOrigin$ 0.993,0.516&�6�   $��1��6�   6�   �� 5   
   -   5        $ electrickList��5      $'��!Список электричек��6(   $��1��6D   $
��Left=�6T   $��
204,56,0,0q�6o   $	��Top=�6�   $	��124��6�   $��2��6�   $��46��6�   6�   �� 5   
   -   5        $��AddElectric��5      $��2��6$   $��Добавить��68   $��1��6K   $
��Left=�6[   $��204,127,0,0q�6v   $	��Top=�6�   $	��124��6�   $ 0.404,5.183&�6�   $��46��6�   6�   �� 5    
   -	   5        $ UkrainRailways��5       $"��Список филий УЗ��6)   $��2��6C   $
��Left=�6S   $��	88,56,0,0q�6n   $	��Top=�6�   $	��124��6�   $��46��6�   6�   �� 5!   
   -
   5        $ 
AddUZFiliy��5!      $!��Добавить филию��6%   $��2��6>   $
��Left=�6N   $��
88,127,0,0q�6i   $	��Top=�6}   $	��124��6�   $ 0.404,5.183&�6�   $��46��6�   6�   �� 5"   
   -   5        $ StationsList��5"      $!��Список станций��6'   $��3��6@   $
��Left=�6P   $��0,56,0,0q�6k   $	��Top=�6}   $	��124��6�   $��46��6�   6�   �� 5#   
   -   5        $ 
AddStation��5#      $%��Добавить станцию��6%   $��3��6@   $
��Left=�6P   $��	0,127,0,0q�6k   $	��Top=�6~   $	��124��6�   $��46��6�   6�   �� 5$   
   -   5        $0��*Рассписание по станции��5$      $��3��62   $
��Left=�6B   $��
142,62,0,0q�6]   $	��Top=�6q   $	��134��6�   $��40��6�   $��2��6�   �� 5%   
   -   5        $/��)Добавить рассписание
��5%      $��3��6:   $
��Left=�6J   $��142,135,0,0q�6e   $	��Top=�6z   $	��134��6�   $��46��6�   $��2��6�   �� 5&   
   -   5        $��ModeType��5&      $��5��6#   $��3��63   $��48,160,10,-10q�6m   �� 5'   
   -   5        $ LoodCiti��5'      $��4��6#   $��129,39,133,142q�63   $��2��6b   $#��Заливка городов��6v   �� 5(   
   -   5        $ 	LoadDepot��5(      $��4��6$   $��129,110,133,71q�64   $��2��6L   $��Заливка депо��6`   6w   �� 5)   
   -   5        $ LoadLocSeriese��5)      $��4��6)   $��129,62,133,119q�69   $��Заливка депо��6Q   $��2��6h   6|   �� 5*   
   -   5        $ 
GetTrrains��5*      $��4��6%   $��129,156,133,25q�65   $��2��6M   $-��'Загрузка локосотивов��6a   6�   5+      5,      