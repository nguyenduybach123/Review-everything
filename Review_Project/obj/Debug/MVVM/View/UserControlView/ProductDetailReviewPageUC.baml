   M S B A M L   `   `   `  ����I  EReview_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Review_Project.MVVM.View.UserControlView(Review_Project.MVVM.View.UserControlView  5      M+clr-namespace:Review_Project.MVVM.ViewModelReview_Project.MVVM.ViewModel  5      H    BReview_Project.MVVM.View.UserControlView.ProductDetailReviewPageUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:Review_Project.MVVM.View.UserControlView     5      A	viewModel+clr-namespace:Review_Project.MVVM.ViewModel     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5        $��productCommentPageUC��5        � 	Resources  5       �� 
TargetType   
btnSeeMore �� Property �� Value �� Triggers P� Property P� Value  btnSendComment �� 
TargetType'  !MaterialDesignThemes.Wpf.PackIcon   Kind  btnMedia��%�  &	        &	 m    &	 3    �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   66   �� 5       � ��$ SemiBold"�6+   6>   �� 5       � ��
 �����6;   �� 5       � ��$ 
20,10,0,10q�6'   6<    5      P� 5       �@J�IsMouseOver . . �5      ��  �@�Cursor$
 Hand��6/   6>   �� 5       � ��
 �����6L   5      5      �� 5   
   " ��6'   .�5      ��  � ��
 �����6;   �� 5        � �� 5!      �� 5"      " ��6&   .R�5#      �� 
������ .��5$        $
 Send=�66   $��35��6B   $��35��6M   #��z��5%   6   6b   5&      5'      5)       5+      P� 5,       � {� .  . �5-      ��  � �� �#3336B   5.      P� 5/       �@J�IsMouseOver . . �50      ��  � ��
 ��� �6B   51      53      �� 55   
   " ��6!   .�56      ��  � ��
 �����6;   �� 57       �@�Cursor$
 Hand��6'   66   �� 58       � �� 59      �� 5:      " ��6&   .R�5;      �� 
������ .��5<        $ Camera=�66   $��35��6D   $��35��6O   #��z��5=   6   6b   5>      5?      5A       5C      P� 5D       �@J�IsMouseOver . . �5E      ��  � ��
 ��� �6B   5F      5H      5J      .  (System.Windows.Interactivity.Interaction	   Triggers	 5L      /  )System.Windows.Interactivity.EventTrigger  5M   
   
   	EventName$
 Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5N      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *!LoadedProductCommentPageCommand+   CommandParameter 6X   ��  �� ElementName$ productCommentPageUC��5O      .��5R      ��  �� CornerRadius$ 20��6   
������ ._�5U   
   �� .+�5V      �� $��	0,10,0,20q�6    �� Orientation$ 
Horizontal=�6,   .+�5W      �� $��	30,15,0,0q�6   $��30(�5X      
�������$��SemiBold"�6=   Bình Luận6_     5Z      $ CommentTextMultiple=�6*   $��	10 10 0 0q�6E   $��40��6X   $��40��6c   
�������$��Center=�5[   *   $��Center=�6G   6d   5\      � 5_      -   5         �Name$ userComment��5_      $��20q�6(    � ColumnDefinitions 5`      �� 5a      $	��100 �6'   65   �� 5b      6)   .+�5e      � $��0��6   .+�5f      �� $	 100��6   $��70��60   $��70��6;   $��0,10,0,0q�6G   $��Center=�5g      $	��Top=�6:    J� Effect 5i      3  -System.Windows.Media.Effects.DropShadowEffect  5j      61   ._�5m      A� ��5n      �� 5o   "   -   5        userImg�� j� Stretch$
 Fill=�5o   >   6O   5q      5r      5s      �� 5u      $��1��6   .+�5v      �� -   5         ��Name$ 
txtComment��5v      $��40��5w      $	��Top=�6*   $��0,10,0,0q�6B   $��5q�6T   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Bình Luận��5x      .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����$��18(�5z      $��SemiBold"�6,   
�������.��6U   	 5|        5}      $
 TextChanged��6-   . 5~   "      68   �� * TextChangedCommentInputCommand+ 6k   �� $ productCommentPageUC��5      .��5�   2   5�      � 5�      .+�5�      �� $ 
Horizontal=�6%   $
��Left=�5�   %   $��Center=�6@   .+�5�      �� -   5         ��Name$ btnMedia��5�   %   #��[ 67   $��10,0,0,0q�6Y   $��5q�6k    � Cursor$
 Hand��6w   ��5�   %   �� *SubmitMediaButtonCommand+��6R   �� $ productCommentPageUC��5�      5�      �� 5�      $ 
Horizontal=�6%   $��	0,10,0,10q�6>   $��Right=�5�   !   $��Center=�6=   .+�5�      �� -   5        $ 	btnSubmit��5�   %   #��[ 68   $��	10,0,10,0q�6`   ��5�   %   �� *SubmitCommentButtonCommand+��6T   �� $ productCommentPageUC��	 5�   "     5�   &   $
 Loaded��65   . 5�   *      6@   �� *LoadedSubmitButtonCommand+ 6n   �� $ 	btnSubmit��5�   '   5�      5�      5�      � 5�      -   5        $ MediaControl��5�      $��0,20,0,0q�5�      $y�	Collapsed=�6-    � RowDefinitions 5�      �� 5�      6.   �� 5�      6.   .+�5�      � $��0��6   $��Right=�6,   .+�5�      �� -   5        $ btnCloseMedia��5�   %   ��5�   %   �� *SubmitCloseMediaButtonCommand+��6W   �� $ productCommentPageUC��.��6�   X6�   5�      �� 5�      -	   5         ��Name$ MediaContainer��5�   %   $��1��6=   $ 
Horizontal=�5�   !   $��Center=�6:   5�      5�      5�      5�      � 5�        5�        SrcollHidden �� Binding �� Path �� Value��%J  &	       �� 5�      " ��6    5�      �� 5�       6*   �� $ CommentContainer��$ ActualHeight� 3006n   .a�5�   "   ��  � y�$ 	Collapsed=�6?   5�      �� 5�       6*   �� $ CommentContainer��$ ActualHeight� 3016n   .a�5�   "   ��  � y�$ Visible=�6?   5�      5�      5�      .+�5�      � .+�5�      �� -
   5         ��Name$ scrollCommentContainer��5�   #   $	��300��6C   .��5�      �� .+�5�      �� -   5        $ CommentContainer��5�   )   	 5�   "     5�   &   $
 Loaded��65   . 5�   *      6@   �� *LoadedCommentContainerCommand+ 6r   �� $ productCommentPageUC��5�   '   .+�5�   "   � -   5        $ emptyBox��5�   '   .+�5�   &   �� $��80,20,20,20q�60   $��30(�6E   
�������$��SemiBold"�6f   $��Center=�5�   0   $��Center=�6M   $"Chưa có ai bình luận cả :((5�   '   �� 5�   &   $	��100��6,   $��Right=�69   $��/Images/GUI/onabreak.png��6U   5�   #   5�      � 5�      .+�5�   "   �� -   5          ��Name$  
btnSeeMore��5�   ,   #��[  6@   	 5�   &     5�   *   $
 MouseLeftButtonDown��69   . 5�   .      6D   �� *SubmitSeeMoreCommentCommand+ 6t   �� $ productCommentPageUC��5�   +   Xem Thêm Bình Luận5�   #   5�      5�      5�      5�      5�      5�      5�      5�      