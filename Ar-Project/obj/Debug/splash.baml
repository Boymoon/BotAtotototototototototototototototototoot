   M S B A M L   `   `   `  ����E  AAr-Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project  5   	       Ar_Project.splash   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Ar_Project     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6N   -   5          � Title$  splash��5	   	   $	��263��6   $	��489��6%    � WindowStyle$
 None=�61    � AllowsTransparency . ���	#FF333333$��1q�6u   ���	#FFFF8F17 � WindowStartupLocation$ CenterScreen=�6�   .��5
      � $��-1.5,0,1.5,0q�6   '  !System.Windows.VisualStateManager   VisualStateGroups 5   
   %  System.Windows.VisualStateGroup  5      -   5        VisualStateGroup��   Transitions 5      %  System.Windows.VisualTransition  5         GeneratedDuration$ 0D�6'   	   To$ VisualState��6=      
Storyboard. 5      �� .��5      �� 	 �� TargetProperty$	 (TextBlock.Text)�6<   
 �� 
TargetName$
 	textBlock��6i   .�5   "   a�  �� KeyTime$ 0:0:6��69    �� Value$ 
Loading...��6I   5      U� 5      $	 (RangeBase.Value)�6<   $
 progressBar��6j   .\�5   "   9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� KeyTime$ 0��67    O� Value$ 0Q�6C     5   "   $ 0:0:6��67   $	 100Q�6G   5      �� 5      $#	 (ProgressBar.IsIndeterminate)�6=   $
 progressBar��6w   .p�5   "   s�  �� KeyTime$ 0��6:    �� Value . 6F   s� 5   "   $ 0:0:6��6:    .  6J   5      5      5         States. 5         System.Windows.VisualState  -   5        VisualState��   
Storyboard. 5      �� .��5       �� $	 (TextBlock.Text)�68   $
 	textBlock��6e   .�5!      a� $ 0:0:11��65   $ 
Loading...��6F   5"      5#      5$      5%      .+�5'   
   � -   5         �Name$ progressBar��5'      $��10��6+   $��Bottom=�67   $��72.167,0,42.833,89q�6R    � IsIndeterminate . .  (System.Windows.Interactivity.Interaction   Triggers 5(      /  )System.Windows.Interactivity.EventTrigger  5)         	EventName$ Loaded��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5*      =	  7Microsoft.Expression.Interactivity.Core.GoToStateAction	   	  	StateName$ VisualState��6)   5+      5-      �� 5.   
   -   5         ��Name$ 	textBlock��5.      $
��Left=�6'   $��74.167,143,0,91q�6B   $
��Wrap=�6[   $��219.333��6o   ���	#FFCDCDCD$��	Loading..��6�   6�   �� 5/   
   -   5        $ 
textBlock1��5/      $��80��6(   $��146.745,44,217.5,0q�64   $
��Wrap=�6P   $	��Cor��6d   $	��Top=�6o   ���	#FFD1D1D1$��64(�6�   �� 50   
   -   5        $ textBlock1_Copy��50      $��80��6-   $��251.755,46,121.755,0q�69   $
��Wrap=�6W   $��VK��6k   $	��Top=�6u   ���	#FFFF8500$��64(�6�   51      52      