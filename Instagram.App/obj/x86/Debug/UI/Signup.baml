   M S B A M L   `   `   `  ����H  DInstagram.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Instagram.AppInstagram.App  5          Instagram.App.UI.Signup   5      a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7signupviewmodelclr-namespace:Instagram.App     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      HCustom;http://schemas.devexpress.com/winfx/2008/xaml/core/internal  5        � Title$(  "تسجيل حسابات جديدة��5
      $��529.185��6   $��741.966��6.    � WindowStartupLocation$ CenterScreen=�6>    � 
ResizeMode$ NoResize=�6c    � DataContext 5      #   Instagram.App.SignupViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��505 �6   �� 5      $��77.349 �6   .+�5   
   �� ���	#FF007ACC$��	0.7,0,0,0q�6)    �� CornerRadius$ 2��6E   $��0,10,-148.5,0q�6V   $��Right=�6m   $��227.349��6�   $��2��6�   ._�5      �  � RowDefinitions 5      �� 5      $	��73* �6$   �� 5      $��230.119 �6$   �� 5      $
��187* �6$   .+�5      �� $��0,0,10,-0.001q�6   $��3��64   .+�5      %  DevExpress.Xpf.Editors.TextEdit  $��2,80,0,0q�6#   $��Right=�65   %  DevExpress.Xpf.Editors.BaseEdit   NullText$ الايميل��6X   )  #DevExpress.Xpf.Editors.TextEditBase   NullTextForeground �	#89000000	   Text	 5       �� *Email+
 �� UpdateSourceTrigger$
 PropertyChanged=�{�5!      ��  �� ElementName$ IsAutoSignup�� �� Path$ 	IsChecked�   ConverterIsEnabled �� 	Converter# [    5#      $��2,10,0,0q�6#   $��Right=�65   $ الاسم الكامل��6X    �	#89000000	 5$      �� *
Fullname+$
 PropertyChanged=�{�5%      �� $ IsAutoSignup��$ 	IsChecked�# [    5(      $��2,10,0,0q�6#   $��Right=�65   $ اسم المستخدم��6X    �	#89000000	 5)      �� *
Username+$
 PropertyChanged=�{�5*      �� $ IsAutoSignup��$ 	IsChecked�# [  ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5-      $��	2,10,0,50q�6*   $��Right=�6=   $ كلمة المرور��6`    �	#89000000	 5.      �� *
Password+$
 PropertyChanged=�{�5/      �� $ IsAutoSignup��$ 	IsChecked�# [  �� 53      -   5         ��Name$ 
Btn_signup��53   ,   
 J� Uid$ UserPlus��6   $��Signup��6A   $"��تسجيل حساب جديد��6[   $��28��6�     CustomButton#���  6�   $��45.974,0,46.008,0q�6�    � Cursor$
 Hand��54   �   ��53   u   �� *SignupCommand+{�54      �� $ IsAutoSignup��$ 	IsChecked�# [  6�   57      �� 58      $��2��6   ���	#FF007ACC$��	0,0.7,0,0q�6>   $ 3��6Z   $��0,0.001,0,-0.001q�6k   ._�59      �� $��1��6!   .+�5:      &   DevExpress.Xpf.Editors.CheckEdit  -   5        $��IsAutoSignup��5:   (   $��103.333,0,0,0q�6<      Content)  #DevExpress.Xpf.Core.ObjectConverter$* $تفعيل التسجيل الآلي 6S   �� 5;      -   5        $��btn_MultiSignup��5;   !   #���  6�   $��25.118��6  $��161.333,5,7,10q�6  $��10(�6)  $
 Hand��5<   X   ��5;   8   �� *	Content+$
 PropertyChanged=� �� FallbackValue$ بدأ�� 6�   �� *Icon+$
 PropertyChanged=�$
 Play��{�5<      �� *	IsChecked+$ IsAutoSignup����5=      �� *MultiSignupCommand+$
 PropertyChanged=���5>      �� *CommandParam+$
 PropertyChanged=�$ MultiSignup�� 5?   !   �� *CustomButton+�� 5A       �� Orientation$ 
Horizontal=�6%   .+�5B      �� ���	#FFDE1A1A$��218.333,0,0,0q�6?   $
��9.96��6V   *6g   �� 5C      ���	#FFDE1A1A$��
-100,0,0,0q�6?   $
��9.96��6S   *6d   5E      �� 5F      $ 
Horizontal=�6%   $��10,0,0,0q�6>   .+�5G        $	 100��6T   $��4,0,0,0q�6c   $��Right=�6t   $��113.5��6�    �	#9E000000���	#FF007ACC � ToolTip 6+   �� $ tooltiop��{�5H      �� $ IsAutoSignup��$ 	IsChecked�	 5I      �� *To+$ 2��  5K      $ 0��6T   $��4,0,0,0q�6a   $��Right=�6r   $��95.083��6�    �	#9E000000���	#FF007ACC 6+   �� $ tooltiop��{�5L      �� $ IsAutoSignup��$ 	IsChecked�	 5M      �� *From+$ 1��5P      �� 5Q      $y�	Collapsed=�6%   $��	0,8,0,-30q�6<   $��81��6O   .+�5R      �� $��WrapWithOverflow=�6(    �� TextAlignment$ Right=�6I   $��73.293��6_   $��14(�6o   �� 6~   $� ��6�    �� 5T   #   
���  ��$�*��68    �� TextAlignment$ Right=�6A    �� BaselineAlignment$ 	Subscript=�6]   $��Segoe UI Semibold)�6{   $
��Thin"�6�   .�6�   5V   $    �� 5W   "   -   5        $��tooltiop��5W   ,   $
��Wrap=�6<   $��0,-8,0,0q�6P   $��59.63��6b   $��223.403��6q   �� 5X   %   ���	#FF060606$~�x عند تفعيل خيار التسجيل الآلي يجب  وضع فاصل زمني بين كل عملية تسجيل��6A   $ 	Subscript=�6�    �� FlowDirection$ RightToLeft=�6�   5Z   #   5\      5]      5^      5_      �� 5`      $��0��6   $��0,0.7q�6&   $ 3��6>   ���	#FF007ACC._�5a      �� .+�5b      �� $��0,2,7,10q�6$   $ Right=�66   $��14(�6L   �� 6\   $�تم تسجيل:��6`   �� 6s   $� ��6w   �� 6�   $
��Bold"�6�   ���	#FF2C2C2E�6�   �� *Count+$ 0��$
 PropertyChanged=��� 6�   $� ��6  �� 6  $�حساب��6  6   �� 5c      $��0,0,7,10q�6$   $ Right=�66   $��14(�6L   �� 6\   $!�لم يتم التسجيل:��6`   �� 6y   $� ��6}   �� 6�   $
��Bold"�6�   ���	#FF2C2C2E�6�   �� *unregistered+$ 0��$
 PropertyChanged=��� 6  $� ��6  �� 6  $�حساب��6  6-  5e      5g      5h      5i      %  DevExpress.Xpf.Grid.GridControl  5k   
   )	  #DevExpress.Xpf.Grid.DataControlBase( 	  !DesignTimeUseDistinctSampleValues .  	  AutoGenerateColumns$ KeepOld=�6n   # 	  EnableSmartColumnsGeneration . $��10,10,1.598,0q�6�    	  ItemsSource 6C   �� *CollectionOfSignup+   Columns 5m      $
  DevExpress.Xpf.Grid.GridColumn
  5n      $  DevExpress.Xpf.Grid.BaseColumn   Width$
 auto��6!   $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ كلمة المرور��6.       Binding  6F   �� *
Password+
  5o      $
 auto��6!   $ الايميل��6.     6B   �� *Email+
  5p      $
 auto��6!   $ اسم المستخدم��6.     6G   �� *
Username+!   View! 5t      #  DevExpress.Xpf.Grid.TableView  5u      "   AllowPerPixelScrolling" . &   DevExpress.Xpf.Grid.GridViewBase#   ShowGroupPanel# .  $   	AutoWidth$ . 6U   5x      5{      5|      