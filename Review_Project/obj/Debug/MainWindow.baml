   M S B A M L   `   `   `  ����I  EReview_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Review_Project.MVVM.View.UserControlView(Review_Project.MVVM.View.UserControlView  5   	   M+clr-namespace:Review_Project.MVVM.ViewModelReview_Project.MVVM.ViewModel  5   	   /clr-namespace:Review_ProjectReview_Project  5	   	       Review_Project.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Euc6clr-namespace:Review_Project.MVVM.View.UserControlView     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   ;	viewModel+clr-namespace:Review_Project.MVVM.ViewModel  5   	   (localclr-namespace:Review_Project  5	   	   -   5        $��
mainWindow��5   	     � Title$  
MainWindow��5   	   $	��860��6   $
��1320��6)    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      7   1Review_Project.MVVM.ViewModel.MainWindowViewModel  5   
   6*   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadedWindowCommand+
   CommandParameter
 6L   ��  �� ElementName$ 
mainWindow��5      .��5      ��  �� CornerRadius$ 10��6   
������ ._�5   
   � .+�5       � $��1��6   $��10q�6    $��Center=�6,   $��Center=�6I   .+�5!      �� $��Center=�5"   !   $��Center=�5#   !   ��5!   !   �� *CurrentView+5#   >   5$      5%      5&      5'      