   M S B A M L   `   `   `  ����I  EReview_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Review_Project.MVVM.View.UserControlView(Review_Project.MVVM.View.UserControlView  5      D    >Review_Project.MVVM.View.UserControlView.ProducerProfileInfoUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:Review_Project.MVVM.View.UserControlView     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��	profileUC��5	      $
��1000��5
        � 	Resources  5       �� 
TargetType   OverViewInfoTheme �� Property �� Value  txbOverViewInfoTheme  txtButtonTheme �� Triggers P� Property P� Value " PrimaryHueMidForegroundBrushss �� Color��%  &	        &	     &	 �    &	 �    �� 5   
   " ��6   .�5      ��  � ��$	 120��6&   64   �� 5       � ��$ 70��6'   64   �� 5       � ��$ Center=�64   6E   �� 5       � ��$ Center=�62   6C   �� 5       � ��$ 20 10 20 10q�6'   6=   5      �� 5   
   " ��6   .�5      ��  � ��$ 25(�6)   66   �� 5       � ��
 �����6;   �� 5       � ��$ SemiBold"�6+   6>   �� 5       � ��$ Center=�64   6E   �� 5       � ��$ Center=�62   6C   5      �� 5   
   " ��6'   .�5      ��  �@�Cursor$
 Hand��6'   66    5!      P� 5"       �@J�IsMouseOver . . �5#      ��  � ��
 � ���6D   5$      5&      �� 5(   
   $	 Red��6A   5*      .  (System.Windows.Interactivity.Interaction   Triggers 5,      /  )System.Windows.Interactivity.EventTrigger  5-   
   	   	EventName$	 Loaded��6   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5.      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� * LoadProducerProfileInfoCommand+   CommandParameter 6W   ��  �� ElementName$ 	profileUC��5/      .��52      ��  �� Padding$ 10q�6    �� CornerRadius$ 20��53      ���#313338._�55   
   �  � ColumnDefinitions 56      �� 57      $	��450 �6#   61   �� 58      6%   .+�5;      �� $��0��6   ._�5<      �� .+�5?      � 6   � 5B      $	��300��6   .+�5C      �� $��0��6!   $	 100��5D   %   $��10q�5E   %   $ 5q�5F   %   
�������$	��220��5H   %   $	��220��61   $	��Top=�5I   %    J� Effect 5K      3  -System.Windows.Media.Effects.DropShadowEffect  5L   "   65   ._�5O      A� ��5P   "   �� 5Q   &   -   5        userImg��5Q   D   5S      5T      A   ;Review_Project.MVVM.View.UserControlView.ButtonCircleIconUC  5V      $��60��63   $��60��6>      Background1$ 	AliceBlue��5W   3      Background2$
 Aqua��6K      Icon$
 Plus=�5X   3   
���   �   	WidthIcon$ 40��5Y   3      
HeightIcon$ 40��6B   $��296,216,69,24q�6R   6k   5[      �� 5]      .+�5^      �� -   5        $��userName��5^   $   #��[ 64   Nguyễn Duy Bách6s   �� 5_       �� Orientation$ 
Horizontal=�6%   $��Center=�5`   %   $��Center=�6B   $��0,10,0,0q�5a   %   .+�5b      (  "MaterialDesignThemes.Wpf.RatingBar  -   5          Name$ userStarRating��5c   #      IsPreviewValueEnabled . 
   Max$ 4��5e   #   
   Min$ 0��6+      Orientation$ 
Horizontal=�5f   #      ValueIncrements$	 0.5Q�5g   #      Value$	 4.5Q�5h   #      ValueItemTemplate 5i   "   �� 5j   &     �� DataType$  system:Int32��63   .R�5k   *   � .+�5l   .   '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5m   /   $��40��6:   !   Kind$
! Star=�6F   5n   +   5o   '   5q      �� 5s      -   5        $��userPointRating��5s   (   #��[ 6?   $��20,0,0,0q�6m   4.56�   5u      �� 5v      $ 
Horizontal=�6%   $��Center=�5w   %   $��Center=�6B   .+�5x      �� #��[ 6(   $��	10,0,10,0q�6V   	Like: 1006t   �� 5y      #��[ 6(   $��	10,0,10,0q�6V   Dislike: 1006w   5z      5{      5~      5      �� 5�      $��1��6   ._�5�      �� $��0,50,0,0q�6   .+�5�      �� $ 15��6   
�������$��	0,10,0,20q�5�      ._�5�      � .+�5�      9� 
������ $��Stretch=�5�      ��5�   "   �� 5�   &   $��20(�60   $��SemiBold"�6>   Chủ đề quan tâm :6g   .��5�   "   �� -   5        " ��Name$" userPostTypeCare��5�   -   $��
24,8,24,16q�6G   $ Vertical=�5�   .     MaterialDesignBody#���  5�   .   .+�5�   &   � -   5        # �Name$# emptyBox��5�   +   .+�5�   *   �� $��Center=�64   $��Center=�6Q   $��30(�5�   4   $��SemiBold"�6B   EMPTY6_   �� 5�   *   $��70��60   $��Right=�6<   $��/Images/GUI/onabreak.png��6X   5�   '   5�   #   5�      5�      5�      �� 5�      $ 
Horizontal=�6!   $��Center=�5�   !   $��Center=�6>   .+�5�      9	   3Review_Project.MVVM.View.UserControlView.CardInfoUC	  -   5        $ 	 Name$$ userNumberPost��5�   +   $	��150��6C   % 	  Icon$% NoteEdit=�5�   +   & 	  	WidthIcon$& 30��6;   ' 	  
HeightIcon$' 30��6J   $��	10,0,10,0q�6Z   ( 	  Background1$( White��5�   +   ) 	  Background2$) 
WhiteSmoke��6?   * 	  BackgroundEllipse1$* #333333��5�   +   + 	  BackgroundEllipse2$+ #333333��6H   
���   �, 	  Title$, Bài Viết :��5�   >   - 	  Value$	- 100��6Q   . 	  FontSizeTitle$. 20��5�   +   / 	  FontSizeValue$/ 25��6>   6S   	  5�      -	   5        $$ 
userNumber��5�   +   $	��150��6?   $% AccountHeart=�5�   +   $& 30��6@   $' 30��6O   $��	10,0,10,0q�6_   $( White��5�   +   $) 
WhiteSmoke��6?   $* #333333��5�   +   $+ #333333��6H   
���   �$, 	Uy Tín :��5�   >   $	- 100��6O   $. 20��5�   +   $/ 25��6>   6S   	  5�      -
   5        $$ userNumberFollower��5�   +   $	��150��6G   $% 
AccountEye=�5�   +   $& 30��6>   $' 30��6M   $��	10,0,10,0q�6]   $( White��5�   +   $) 
WhiteSmoke��6?   $* #333333��5�   +   $+ #333333��6H   
���   �$, Theo Dõi :��5�   >   $	- 100��6Q   $. 20��5�   +   $/ 25��6>   6S   5�      �� 5�      $��	0,20,0,10q�6   $ 15��5�      
�������._�5�      �� .+�5�      �� $��	10,10,0,0q�6(   $��20(�6;   $��SemiBold"�6I   Danh sách theo dõi :6u   �� 5�      -   5        $��userFollowerList��5�   )   $ 
Horizontal=�6A   .+�5�   "   �� -   5        $��emptyFriend��5�   ,   $��16(�6?   $��180,10,0,10q�6M   $��Center=�5�   ,   $��Center=�6I   Chưa theo dõi ai hết :>>6~   5�      �� 5�      -   5        0 ��Name$0 btnFriendSeeMore��5�   (   #��[ 5�   (   $��16(�5�   (   $��SemiBold"�66   $��Right=�5�   (   $��5,5,15,5q�5�   (    5�   &     5�   *   $	 MouseLeftButtonDown��69   .
 5�   .      6D   �� *OpenFriendListWindowCommand+ 6t   �� $ 	profileUC��5�   +   Xem Thêm >>5�      5�      5�      5�      5�      5�      5�      5�      