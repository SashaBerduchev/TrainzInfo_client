   M S B A M L   `   `   `  ���� L  HTrainzInfo_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TrainzInfo_clientTrainzInfo_client  "    TrainzInfo_client.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:TrainzInfo_client       � Title$  
MainWindow��$	��850��$
��1200�� � WindowState$ 	Maximized=�.���  � ColumnDefinitions �� �� �� �� �� ��  � RowDefinitions �� �� �� �� .+��� -    ��Name$ listinfo��$��1��$��0��$��4��$��3���� -    ��Name$ btnLoad��$5��/Загрузка новостей с сайта��$
��Left=�$��	37,56,0,0q�$	��Top=�$	��120��$��46���� -   $ 
btnNewsAdd��$#��Создать новость��$
��Left=�$��
37,127,0,0q�$	��Top=�$	��120��$��46���� -   $ btnElectric_locomotives��$+��%Список электровозов��$
��Left=�$��
209,56,0,0q�$	��Top=�$	��120��$��46��$��2���� -   $ ElectrickLocomotiveAdd��$+��%Добавить электровоз��$
��Left=�$��209,127,0,0q�$	��Top=�$	��120��$��46��$��2���� -   $  btnDiesel_locomotives_Copy��$'��!Список тепловозов��$
��Left=�$��	60,56,0,0q�$	��Top=�$	��120��$��46�� J� RenderTransformOrigin$ 0.993,0.516&�$��1���� -   $ electrickList��$'��!Список электричек��$��1��$
��Left=�$��
204,56,0,0q�$	��Top=�$	��124��$��2��$��46���� -   $��AddElectric��$��2��$��Добавить��$��1��$
��Left=�$��204,127,0,0q�$	��Top=�$	��124��$ 0.404,5.183&�$��46���� -	   $ UkrainRailways��$"��Список филий УЗ��$��2��$
��Left=�$��	88,56,0,0q�$	��Top=�$	��124��$��46���� -
   $ 
AddUZFiliy��$!��Добавить филию��$��2��$
��Left=�$��
88,127,0,0q�$	��Top=�$	��124��$ 0.404,5.183&�$��46���� -   $ StationsList��$!��Список станций��$��3��$
��Left=�$��0,56,0,0q�$	��Top=�$	��124��$��46���� -   $ 
AddStation��$%��Добавить станцию��$��3��$
��Left=�$��	0,127,0,0q�$	��Top=�$	��124��$��46���� -   $0��*Рассписание по станции��$��3��$
��Left=�$��
142,62,0,0q�$	��Top=�$	��134��$��40��$��2���� -   $/��)Добавить рассписание
��$��3��$
��Left=�$��142,135,0,0q�$	��Top=�$	��134��$��46��$��2���� -   $��ModeType��$��5��$��3��$��48,160,10,-10q��� -   $ LoodCiti��$��4��$��129,39,133,142q�$��2��$#��Заливка городов���� -   $ 	LoadDepot��$��4��$��129,110,133,71q�$��2��$��Заливка депо���� -   $ LoadLocSeriese��$��4��$��129,62,133,119q�$��Заливка депо��$��2���� -   $ 
GetTrrains��$��4��$��129,156,133,25q�$��2��$-��'Загрузка локосотивов��