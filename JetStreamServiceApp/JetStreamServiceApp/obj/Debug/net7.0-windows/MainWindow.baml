   M S B A M L   `   `   `  ����N  JJetStreamServiceApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:JetStreamServiceApp.ViewModelsJetStreamServiceApp.ViewModels  5   	   $    JetStreamServiceApp.AdminPanel   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;vm,clr-namespace:JetStreamServiceApp.ViewModels     5   	   -   5          � Title$  Admin Panel��5   	   $
��1000��6   $
��1500��6+    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$ SingleBorderWindow=�6.    � DataContext 5      2   ,JetStreamServiceApp.ViewModels.MainViewModel  5   
    J� InputBindings 5      �� 5   
   
 �� Key$ Enter��6    �� Command 6!   ��  �� Path$ LoginCommand�.��5      � .+�5   
   � -   5         �Name$ GridMain��5      $y�Hidden=�6!   	 � RowDefinitions	 5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 ordersDataGrid��5      $��0��6/      SelectionMode$ Extended=�6^      AutoGenerateColumns$ False��6w      
IsReadOnly$
 True��6�      	RowHeight$ 35Q�6�   $��20(�6�   $
��Left=�6�   $
��Auto��6
  ��6<   �� *	OrderList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	OrderID+6W     5      $ Customer Name��6)   $
 Auto 6a    6@   �� *CustomerName+6a     5      $ Customer Email��6)   $
 Auto 6c    6A   �� *CustomerEmail+6c     5      $ Customer Phone��6)   $
 Auto 6c    6A   �� *CustomerPhone+6c     5      $ Priority��6)   $
 Auto 6X    6;   �� *
Priority+6X     5      $ Service Type��6)   $
 Auto 6_    6?   �� *ServiceType+6_     5      $ Create Date��6)   $
 Auto 6]    6>   �� *
CreateDate+6]     5      $ Pickup Date��6)   $
 Auto 6]    6>   �� *
PickupDate+6]     5       $ Status��6)   $
 Auto 6T    69   �� *Status+6T     5!      $ Comment��6)   $
 Auto 6V    6:   �� *	Comment+6V   5#      �� 5'      $��1��6    �� Orientation$ 
Horizontal=�6&   $
��Left=�6?   $��Bottom=�6Z   $��10,10,10,10q�6u   .+�5)      �� $��Aktualisieren��69   $��50��6Q   $	��170��6]   ���#cccccc
���   �$��0,0,10,0q�6�   $��25(�6�   ��6   �� *LoadCommand+��5*      �� 5+       �� 
TargetType" ��6*   .R�5,      �� #��z��6%   
���   �$��1q�6c    �� CornerRadius$ 5��6w   ._�5-   "   �� $��Center=�63   $��Center=�6P   5.      5/      51      �� 53      -   5        $��
Bearbeiten��53   E   $��50��6Z   $	��145��6f   ���#007bff
�������$��0,0,10,0q�6�   $��25(�6�   ��6   �� *LoadResourceByIdCommand+��54      �� 55      " ��6*   .R�56      �� #��z��6%   
���   �$��1q�6c   $ 5��6w   ._�57   "   �� $��Center=�63   $��Center=�6P   58      59      5;      �� 5<      $��Löschen��6;   $��50��6M   $	��131��6Y   ���#dc3545
�������$��25(�6�   ��6   �� *DeleteCommand+��5=      �� 5>      " ��6*   .R�5?      �� #��z��6%   
���   �$��1q�6c   $ 5��6w   ._�5@   "   �� $��Center=�63   $��Center=�6P   5A      5B      5D      �� 5E      -   5         ��Name$ labelID��5E      $��Ausgewählter Auftrag ID:��6)   $
��Left=�6L   $��Bottom=�6g   $��10q�6�   $��25(�6�   �� 5F      -   5         ��Name$ 	textBoxID��5F      $��Bottom=�6n   $��10q�6�   $��25(�6�   $��99��6�    �� 
IsReadOnly$
 True��6�   ��6-   �� *
ResourceId+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5G      5H      � 5L   
   -   5        $ GridEdit��5L      $y�Hidden=�6!   	 5M      �� 5N      $��* �6    �� 5O      $��5* �6    �� 5P      $��* �6     � ColumnDefinitions 5S      �� 5T      $��* �6#   �� 5U      $��2* �6#   �� 5V      $��* �6#   .+�5Y      �� $��10q�6   $��1��6%   $��1��62   .+�5Z      �� $��Auftrags-ID:��6   $��Center=�60   $��18(�6K   �� 5[      $��5q�6f   $��18(�6r   $
 True��6�   ��6   �� *SelectedOrder.OrderID+$ PropertyChanged=�6�   �� 5]      $��Name:��6   $��Center=�6)   $��18(�6D   �� 5^      $��5q�6l   $��18(�6x   ��6   �� *SelectedOrder.CustomerName+$ PropertyChanged=�6x   �� 5`      $��Email:��6   $��Center=�6*   $��18(�6E   �� 5a      $��5q�6m   $��18(�6y   ��6   �� *SelectedOrder.CustomerEmail+$ PropertyChanged=�6y   �� 5c      $��Telefon:��6   $��Center=�6,   $��18(�6G   �� 5d      $��5q�6m   $��18(�6y   ��6   �� *SelectedOrder.CustomerPhone+$ PropertyChanged=�6y   �� 5f      $��Priorität:��6   $��Center=�6.   $��18(�6I   �� 5g      $��5q�6g   $��18(�6s   ��6   �� *SelectedOrder.Priority+$ PropertyChanged=�6s   �� 5i      $��Service:��6   $��Center=�6,   $��18(�6G   �� 5j      $��5q�6j   $��18(�6v   ��6   �� *SelectedOrder.ServiceType+$ PropertyChanged=�6v   �� 5l      $��Erstellungs Datum:��6   $��Center=�66   $��18(�6Q   �� 5m      $��5q�6i   $��18(�6u   $
 True��6�   ��6   �� *SelectedOrder.CreateDate+$ PropertyChanged=�6�   �� 5o      $��Abholungs Datum:��6   $��Center=�64   $��18(�6O   �� 5p      $��5q�6i   $��18(�6u   ��6   �� *SelectedOrder.PickupDate+$ PropertyChanged=�6u   �� 5r      $.��(Status: (Offen, InArbeit, Abgeschlossen)��6   $��Center=�6L   $��18(�6g   �� 5s      $��5q�6f   $��18(�6r   ��6   �� *SelectedOrder.Status+$ PropertyChanged=�6r   �� 5u      $��
Kommentar:��6   $��Center=�6.   $��18(�6I   �� 5v      $��5q�6f   $��18(�6r   ��6   �� *SelectedOrder.Comment+$ PropertyChanged=�6r   �� 5x      -   5        $��Speichern und Schliessen��5x   ;   $��40��6y   $	��270��6�   ���#007bff
�������$��	0,20,10,0q�6�   $��20(�6�   ��6   �� *UpdateCommand+��5y      �� 5z      " ��6*   .R�5{      �� #��z��6%   
���   �$��1q�6c   $ 5��6w   ._�5|   "   �� $��Center=�63   $��Center=�6P   5}      5~      5�      5�      5�      � 5�   
   -	   5        $ 	GridLogin��5�      $y�Visible=�6"   	 5�      �� 5�      $��* �6    �� 5�      $��1* �6    �� 5�      $��* �6     5�      �� 5�      $��* �6#   �� 5�      $
��0.5* �6#   �� 5�      $��* �6#   .+�5�      �� $��10q�6   $��1��6%   $��1��62   .+�5�      �� $��	Username:��6   $��Center=�6-   $��18(�6H   �� 5�      -
   5        $ textBoxUsername��5�      $��5q�63   $��18(�6?   �� 5�      $��	Password:��6   $��Center=�6-   $��18(�6H   G� 5�      -   5         G�Name$ passwordBoxPassword��5�      $��5q�6;   $��18(�6F   �� 5�      -   5        $��Login��5�      $��40��6c   $	��120��6o   ���#007bff
�������$��	0,20,10,0q�6�   $��20(�6�   ��6)   �� $ LoginCommand���5�      �� 5�      " ��6*   .R�5�      �� #��z��6%   
���   �$��1q�6c   $ 5��6w   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      5�      5�      5�      5�      5�      