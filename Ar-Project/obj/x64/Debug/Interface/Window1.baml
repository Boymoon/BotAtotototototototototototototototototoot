   M S B A M L   `   `   `  ����B  >Shannon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project  5   	   5clr-namespace:Ar_Project.AssestAr_Project.Assest  5   	       Ar_Project.Window1   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   $localclr-namespace:Ar_Project  5   	   ,Assestclr-namespace:Ar_Project.Assest  5   	   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5	      <d2http://schemas.microsoft.com/expression/blend/2008   6L   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6�   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6�   h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 6)  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6n  $	��246��5      $	��293��6   ���	#FF333333  � WindowStyle$  ThreeDBorderWindow=�67    � 
ResizeMode$ NoResize=�6X    � 	Resources 5       	  coins �� 	UriSource  1463935404_plus  
dollar-bag  eye (1)  eye (2)  eye (3)  eye 1 -font-awesome_4-7-0_print_1024_256_ecf0f1_none 0 ,font-awesome_4-7-0_print_252_143_ecf0f1_none .	 *font-awesome_4-7-0_print_47_28_ecf0f1_none %
 !horizontal-line-remove-button (2) ! horizontal-line-remove-button  	interface  
line-chart 
 locked  	money-bag  oval (1)  oval (2)  oval (3)  oval  pencil-edit-button  plus-symbol  printer (1)  printer (2)  printer (4)  printer (5)  printer (6)  printer  Printerr  profile 	 reply 
 return   settings (1) ! settings " shopping-cart.png # synchronize.png 	$ users % visible (1) & visible (2) ' visible (3) ( visible ) ButtonControlTemplate1 �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value ��Name J� Opacity��%n  &	        &	 2     &	 n     &	 �     &	 �     &	     &	 A    &	 q    &	 �    &		 $    &	
 {    &	 �    &	     &	 I    &	 �    &	 �    &	 �    &	     &	 S    &	 �    &	 �    &	 �    &	 0    &	 h    &	 �    &	 �    &	     &	 H    &	 |    &	 �    &	 �    &	     &	  J    &	! �    &	" �    &	# �    &	$ *    &	% \    &	& �    &	' �    &	( 	    &	) 8	    7  7  7  7  �� 5      $ ../images/coins.png?�6&   6H   �� 5   
   $# ../images/1463935404_plus.png?�6.   6Z   �� 5   
   $ ../images/dollar-bag.png?�6)   6P   �� 5   
   $ ../images/eye (1).png?�6&   6J   �� 5   
   $ ../images/eye (2).png?�6&   6J   �� 5   
   $ ../images/eye (3).png?�6&   6J   �� 5   
   $ ../images/eye.png?�6"   6B   �� 5   
   $A ;../images/font-awesome_4-7-0_print_1024_256_ecf0f1_none.png?�6L   6�   �� 5   
   $@ :../images/font-awesome_4-7-0_print_252_143_ecf0f1_none.png?�6K   6�   �� 5   
   $> 8../images/font-awesome_4-7-0_print_47_28_ecf0f1_none.png?�6I   6�   �� 5   
   $5 /../images/horizontal-line-remove-button (2).png?�6@   6~   �� 5   
   $1 +../images/horizontal-line-remove-button.png?�6<   6v   �� 5   
   $ ../images/interface.png?�6(   6N   �� 5   
   $ ../images/line-chart.png?�6)   6P   �� 5   
   $ ../images/locked.png?�6%   6H   �� 5   
   $ ../images/money-bag.png?�6(   6N   �� 5   
   $ ../images/oval (1).png?�6'   6L   �� 5   
   $ ../images/oval (2).png?�6'   6L   �� 5   
   $ ../images/oval (3).png?�6'   6L   �� 5    
   $ ../images/oval.png?�6#   6D   �� 5!   
   $&  ../images/pencil-edit-button.png?�61   6`   �� 5"   
   $ ../images/plus-symbol.png?�6*   6R   �� 5#   
   $ ../images/printer (1).png?�6*   6R   �� 5$   
   $ ../images/printer (2).png?�6*   6R   �� 5%   
   $ ../images/printer (4).png?�6*   6R   �� 5&   
   $ ../images/printer (5).png?�6*   6R   �� 5'   
   $ ../images/printer (6).png?�6*   6R   �� 5(   
   $ ../images/printer.png?�6&   6J   �� 5)   
   $ ../images/Printerr.png?�6'   6L   �� 5*   
   $ ../images/profile.png?�6&   6J   �� 5+   
   $ ../images/reply.png?�6$   6F   �� 5,   
   $ ../images/return.png?�6%   6H   �� 5-   
   $  ../images/settings (1).png?�6+   6T   �� 5.   
   $ ../images/settings.png?�6'   6L   �� 5/   
   $! ../images/shopping-cart.png?�60   6Z   �� 50   
   $ ../images/synchronize.png?�6.   6V   �� 51   
   $ ../images/users.png?�6$   6F   �� 52   
   $ ../images/visible (1).png?�6*   6R   �� 53   
   $ ../images/visible (2).png?�6*   6R   �� 54   
   $ ../images/visible (3).png?�6*   6R   �� 55   
   $ ../images/visible.png?�6&   6J   �� 57   
   " ��69   .R�58      �  59        5:      CommonStates��. 5;        
Normal��6&     5<      	MouseOver��. 5=      �� .��5>   "   U� $ (UIElement.Opacity)�6@   $	 image��6p   .\�5?   &     $
 0��6;   $ 1Q�6G     5@   &   $
 0:0:0.1��6;   $ 0Q�6M   5A   #   U� 5B   "   $ (UIElement.Opacity)�6@   $	 image2��6p   .\�5C   &     $
 0:0:0.1��6;   $ 1Q�6M   5D   #   U� 5E   "   $ (UIElement.Opacity)�6@   $	 image1��6p   .\�5F   &     $
 0��6;   $ 1Q�6G     5G   &   $
 0:0:0.1��6;   $ 0Q�6M   5H   #   U� 5I   "   $ (UIElement.Opacity)�6@   $	 image3��6p   .\�5J   &     $
 0:0:0.1��6;   $ 1Q�6M   5K   #   5L      5M        5N      Pressed��6&     5O      Disabled��6&   5P      .+�5R      �� $��1q�6   ._�5S      � .+�5T      �� $ image��6    8��  6/   �� 5U      $ image1��6    8�� $��5.163,3.877,5.337,3.516q�6S   �� 5V      $ image2��6    8�� $ 0Q�6S   �� 5W      $ image3��6    8�� $��18.148��6S   $��18.148��6b   $ 0Q�6r   5X      5Y      5Z      5[      5\      .��5]      �  � ColumnDefinitions 5^   
   �� 5_      $��9* �6   �� 5`      $
��105* �6   �� 5a      $
��146* �6   �� 5b      $	��27* �6    � RowDefinitions 5d   
   �� 5e      $��47 �6   �� 5f      $��22 �6   �� 5g      $��17 �6   �� 5h      $��47 �6   �� 5i      $��39 �6   �� 5j      .+�5l   
   %  DevExpress.Xpf.Editors.TextEdit  -   5          Name$
 name��5l      $��Right=�6%   %  DevExpress.Xpf.Editors.BaseEdit   NullText$ اسم المستخدم��6H   )  #DevExpress.Xpf.Editors.TextEditBase   TextWrapping$
 Wrap=�6`   $��1,-5,3,4q�6t   $��1��6�   $��2��6�   $��1��6�   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5m   
   -   5          Name$
 pass��5m      $��Right=�6,   $ كلمة المرور��6O   $
 Wrap=�6f   $��1,-4,3,0q�6z   $��3��6�   $��1��6�   $��2��6�   $��23��6�   $	��Top=�6�   �� 5n   
   -   5         ��Name$ button��5n      $��تسجيل الدخول��6!   $��0,-8.75,3,13.75q�68   $��4��6f   $��2��6�    J� Effect 5o      3	  -System.Windows.Media.Effects.DropShadowEffect	  5p       	  ShadowDepth$ 2Q�6#   5r      5s      5t      