   M S B A M L   `   `   `  ����A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project  5   	   5clr-namespace:Ar_Project.AssestAr_Project.Assest  5   	       Ar_Project.Window1   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   $localclr-namespace:Ar_Project  5   	   ,Assestclr-namespace:Ar_Project.Assest  5   	   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5	      <d2http://schemas.microsoft.com/expression/blend/2008   6L   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6�   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6�   h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 6)  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6n  j
 fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 
 5
      $	��350��5      $	��400��6     � 
ResizeMode$  NoResize=�6     � WindowStyle$ 
ToolWindow=�66    � 	Resources 5       	  coins �� 	UriSource  1463935404_plus  
dollar-bag  eye (1)  eye (2)  eye (3)  eye 1 -font-awesome_4-7-0_print_1024_256_ecf0f1_none 0 ,font-awesome_4-7-0_print_252_143_ecf0f1_none .	 *font-awesome_4-7-0_print_47_28_ecf0f1_none %
 !horizontal-line-remove-button (2) ! horizontal-line-remove-button  	interface  
line-chart 
 locked  	money-bag  oval (1)  oval (2)  oval (3)  oval  pencil-edit-button  plus-symbol  printer (1)  printer (2)  printer (4)  printer (5)  printer (6)  printer  Printerr  profile 	 reply 
 return   settings (1) ! settings " shopping-cart.png # synchronize.png 	$ users % visible (1) & visible (2) ' visible (3) ( visible ) ButtonControlTemplate1 �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value ��Name J� Opacity��%n  &	        &	 2     &	 n     &	 �     &	 �     &	     &	 A    &	 q    &	 �    &		 $    &	
 {    &	 �    &	     &	 I    &	 �    &	 �    &	 �    &	     &	 S    &	 �    &	 �    &	 �    &	 0    &	 h    &	 �    &	 �    &	     &	 H    &	 |    &	 �    &	 �    &	     &	  J    &	! �    &	" �    &	# �    &	$ *    &	% \    &	& �    &	' �    &	( 	    &	) 8	    7  7  7  7  �� 5      $ ../images/coins.png?�6&   6H   �� 5   
   $# ../images/1463935404_plus.png?�6.   6Z   �� 5   
   $ ../images/dollar-bag.png?�6)   6P   �� 5   
   $ ../images/eye (1).png?�6&   6J   �� 5   
   $ ../images/eye (2).png?�6&   6J   �� 5   
   $ ../images/eye (3).png?�6&   6J   �� 5   
   $ ../images/eye.png?�6"   6B   �� 5   
   $A ;../images/font-awesome_4-7-0_print_1024_256_ecf0f1_none.png?�6L   6�   �� 5   
   $@ :../images/font-awesome_4-7-0_print_252_143_ecf0f1_none.png?�6K   6�   �� 5   
   $> 8../images/font-awesome_4-7-0_print_47_28_ecf0f1_none.png?�6I   6�   �� 5   
   $5 /../images/horizontal-line-remove-button (2).png?�6@   6~   �� 5   
   $1 +../images/horizontal-line-remove-button.png?�6<   6v   �� 5   
   $ ../images/interface.png?�6(   6N   �� 5   
   $ ../images/line-chart.png?�6)   6P   �� 5   
   $ ../images/locked.png?�6%   6H   �� 5   
   $ ../images/money-bag.png?�6(   6N   �� 5   
   $ ../images/oval (1).png?�6'   6L   �� 5   
   $ ../images/oval (2).png?�6'   6L   �� 5    
   $ ../images/oval (3).png?�6'   6L   �� 5!   
   $ ../images/oval.png?�6#   6D   �� 5"   
   $&  ../images/pencil-edit-button.png?�61   6`   �� 5#   
   $ ../images/plus-symbol.png?�6*   6R   �� 5$   
   $ ../images/printer (1).png?�6*   6R   �� 5%   
   $ ../images/printer (2).png?�6*   6R   �� 5&   
   $ ../images/printer (4).png?�6*   6R   �� 5'   
   $ ../images/printer (5).png?�6*   6R   �� 5(   
   $ ../images/printer (6).png?�6*   6R   �� 5)   
   $ ../images/printer.png?�6&   6J   �� 5*   
   $ ../images/Printerr.png?�6'   6L   �� 5+   
   $ ../images/profile.png?�6&   6J   �� 5,   
   $ ../images/reply.png?�6$   6F   �� 5-   
   $ ../images/return.png?�6%   6H   �� 5.   
   $  ../images/settings (1).png?�6+   6T   �� 5/   
   $ ../images/settings.png?�6'   6L   �� 50   
   $! ../images/shopping-cart.png?�60   6Z   �� 51   
   $ ../images/synchronize.png?�6.   6V   �� 52   
   $ ../images/users.png?�6$   6F   �� 53   
   $ ../images/visible (1).png?�6*   6R   �� 54   
   $ ../images/visible (2).png?�6*   6R   �� 55   
   $ ../images/visible (3).png?�6*   6R   �� 56   
   $ ../images/visible.png?�6&   6J   �� 58   
   " ��69   .R�59      �  5;        5<      CommonStates��. 5=        
Normal��6&     5>      	MouseOver��. 5?      �� .��5@   "   U� $ (UIElement.Opacity)�6@   $	 image��6p   .\�5A   &     $
 0��6;   $ 1Q�6G     5B   &   $
 0:0:0.1��6;   $ 0Q�6M   5C   #   U� 5D   "   $ (UIElement.Opacity)�6@   $	 image2��6p   .\�5E   &     $
 0:0:0.1��6;   $ 1Q�6M   5F   #   U� 5G   "   $ (UIElement.Opacity)�6@   $	 image1��6p   .\�5H   &     $
 0��6;   $ 1Q�6G     5I   &   $
 0:0:0.1��6;   $ 0Q�6M   5J   #   U� 5K   "   $ (UIElement.Opacity)�6@   $	 image3��6p   .\�5L   &     $
 0:0:0.1��6;   $ 1Q�6M   5M   #   5N      5O        5P      Pressed��6&     5Q      Disabled��6&   5R      .+�5T      �� $��1q�6   ._�5U      � .+�5V      �� $ image��6    8��  6/   �� 5W      $ image1��6    8�� $��5.163,3.877,5.337,3.516q�6S   �� 5X      $ image2��6    8�� $ 0Q�6S   �� 5Y      $ image3��6    8�� $��18.148��6S   $��18.148��6b   $ 0Q�6r   5Z      5[      5\      5]      5^      .��5_      �  � RowDefinitions 5`   
   �� 5a      �� 5b      $��30 �6   .+�5d   
   *  $DevExpress.Xpf.Core.LoadingDecorator  -   5        $��	isloadedd��5d      $y�Hidden=�61      SplashScreenLocation$ CenterWindow=�6E      	OwnerLock$ LoadingContent=�6i   6�   0 
 *DevExpress.Xpf.LayoutControl.LayoutControl  5f   
   . 
 (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6   .+�5h      - 
 'DevExpress.Xpf.LayoutControl.LayoutItem     LabelHorizontalAlignment$ Center=�6      LabelPosition$	 Top=�6@   $��0,0,0,40q�6T   $��20(�6f      Label$ P a s c a l��6u   ���	#FF062C51   Content. 5i        $ (نسخة تجريبية)��6"   $��13(�69   $	 Top=�6G   $ Center=�6[   ���	#FF1616165k      5l        5o      $ Vertical=�6   .+�5p        . 5q      %	  DevExpress.Xpf.Editors.TextEdit	  -   5         	 Name$
 name��5q   #   $��Right=�61   %
  DevExpress.Xpf.Editors.BaseEdit 
  NullText$ اسم المستخدم��6T   )  #DevExpress.Xpf.Editors.TextEditBase   TextWrapping$
 Wrap=�6l   $��0,0,0,10q�6�   $��1��6�   $��2��6�   $��1��6�   5r        5s      . 5t      ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  -   5          Name$
 pass��5t   *   $��Right=�68   $ كلمة المرور��6[   $
 Wrap=�6r   $��0,10,0,0q�6�   $��3��6�   $��1��6�   $��2��6�   $��23��6�   $	��Top=�6�   5u      5v        5w      . 5x      �� -   5         ��Name$ button��5x      $��تسجيل الدخول��6)   $��
80,20,80,0q�6@   $��4��6i   $��2��6w   5z      5{        5|      $��Center=�6   5�      5�      -  'DevExpress.Xpf.Bars.BarContainerControl  5�   
      ContainerType$ Bottom=�6"   $��1��69      Bars. 5�      *  $DevExpress.Xpf.Bars.StatusBarControl  ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Caption$ 
Status Bar��6#   $��0,5,0,-5q�68      Items. 5�      '  !DevExpress.Xpf.Bars.BarStaticItem  -   5         �Name$ timestorune��5�   $       
ShowBorder  .  !  DevExpress.Xpf.Bars.BarItem!   	Alignment$	! Far=�6�   "   BarItemDisplayMode$" ContentAndGlyph=�6�   #   Content# 68   �� *
timestorun+$ �� UpdateSourceTrigger$$ PropertyChanged=�% �� FallbackValue$% 30��&   Glyph& 6�   *  $DevExpress.Xpf.Core.DXImageExtension  '   Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$' BOUser_16x16.png   5�      )  #DevExpress.Xpf.Core.ObjectConverter$6# 0:عدد مرات التشغيل المتبقية 6$     .  $	! Far=�6\   (   AllowGlyphTheming$
( TrueX�6l   $" Content=�6�   $(& "/Pascal;component/images/Logo2.jpg��6�   )   ContentAlignment$) Center=�6�   5�      5�      5�      5�      