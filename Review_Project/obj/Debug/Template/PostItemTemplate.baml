   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35   PostItemTemplate  ��Name � Cursor �� CornerRadius �� Padding.   (System.Windows.Interactivity.Interaction    Triggers/  )System.Windows.Interactivity.EventTrigger   	EventName.  (System.Windows.Interactivity.TriggerBase   Actions>  8Microsoft.Expression.Interactivity.Core.CallMethodAction   
MethodName   TargetObject	 �� RelativeSource
 �� AncestorType J� Effect3   -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   
BlurRadius   Color   Opacity � ColumnDefinitions j� Stretch �� ImageSource �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon   Kind �� Triggers �� Value �� Binding �� Property �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Bei9http://schemas.microsoft.com/expression/2010/interactions  5      %  &	        �� 5      .R�5	   
   �� $  postContainer��6   $
 Hand��5
      ���#333333$��1q�5      $ 10��5      $ 5q�5      $��2q�6    5        5      $ MouseLeftButtonDown��6!   . 5        $" PostItem_MouseLeftButtonDown��6�    6*   �� *DataContext+	 �� $
 UserControlL�6�   5       5        5      $ 0Q�6#   $ 10Q�63   $ Black��6C   $	 0.5Q�6Q   ._�5      �  5      �� 5      $	��110 �6'   65   �� 5      6)   .+�5!      � $��0��6   .+�5"      �� $	 100��6   $��0,5,0,0q�5#      $��60��5$      $��60��5%      $��Center=�5&      $	��Top=�5'      
������  5*        5+      $ 0Q�6/   $ 10Q�6?   $ Black��6O   $	 0.5Q�6]   ._�5.      A� ��5/      �� 50   "   $
 Fill=�6-    6<   �� *User.Avatar+6b   52      53      54      � 56      $��1��6   $��5,0,0,0q�6'   .+�57      �� .+�59      �� $ 
Horizontal=�6%   .+�5:      �� $��0,0,10,0q�6D   $��16(�5;   )   
���������5:   )   �� *	User.Name+5;   L   �� 5=      $��0,5,10,0q�6D   $��10(�5>   )   
���������5=   )   �� *	CreatedAt+5>   L   5?      �� 5A      $��	0,10,0,10q�6;   $��20(�5B   %   
�������$��SemiBold"�6F   ��5A   $   �� *Title+5B   ^   � 5D      $��0,5,0,5q�6   .+�5F      �� $ 
Horizontal=�6)   $
��Left=�6B   .+�5G   "   �� $ 15��6)   $��1q�6;   
�������$ 5q�5H   )   $��0,0,10,0q�65   ._�5I   &   �� $��16(�60   
�������Quan điểm6\   5J   #   �� 5L   "   $ 15��6)   $��1q�6;   
�������$ 5q�5M   )   $��	10,0,10,0q�65   ._�5N   &   �� $��16(�60   
�������	Góp ý6X   5O   #   5P      �� 5R      $ 
Horizontal=�6)   $��Right=�6B   $��0,0,20,0q�6^   .+�5S   "   �� $ 
Horizontal=�6-   $��15,0,0,0q�6F   .+�5T   &     $	 Eye=�6>   $��0,0,0,5q�6I   
�������$��30��5U   :   $��30��6E   6S   �� 5V   &   $��5,0,0,0q�6F   $��10(�5W   %   
���������5V   0   �� *View+5W   H   5X   #   �� 5Z   "   $ 
Horizontal=�6-   $��15,0,0,0q�6F   .+�5[   &     $ Comment=�6>   $��0,0,0,5q�6M   
�������$��30��5\   :   $��30��6E   6S   �� 5]   &   $��5,0,0,0q�6I   $��10(�5^   %   
���������5]   0   �� *	Comment+5^   H   5_   #   �� 5a   "   $ 
Horizontal=�6-   $��15,0,0,0q�6F   .+�5b   &     $
 Like=�6>   $��0,0,0,5q�6J   
�������$��30��5c   :   $��30��6E   6S   �� 5d   &   $��5,0,0,0q�6F   $��10(�5e   %   
���������5d   0   �� *Like+5e   H   5f   #   5h      5i      5k      5l      5m      5n       5p   
   �� 5q      $
 True��6:    6   �� *IsMouseOver+.a�5r      ��  � �� �#99999966   5s      5v      5w      