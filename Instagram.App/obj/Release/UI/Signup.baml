   M S B A M L   `   `   `  ���� H  DInstagram.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Instagram.AppInstagram.App      Instagram.App.UI.Signup   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7signupviewmodelclr-namespace:Instagram.App     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  f bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   HCustom;http://schemas.devexpress.com/winfx/2008/xaml/core/internal    � Title$(  "تسجيل حسابات جديدة��$��529.185��$��741.966�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � DataContext #   Instagram.App.SignupViewModel  .���  � ColumnDefinitions �� $	��505 ��� $��77.349 �.+��� ���	#FF007ACC$��	0.7,0,0,0q� �� CornerRadius$ 2��$��0,10,-148.5,0q�$��Right=�$��227.349��$��2��._��  � RowDefinitions �� $	��73* ��� $��230.119 ��� $
��187* �.+��� $��0,0,10,-0.001q�$��3��.+�%  DevExpress.Xpf.Editors.TextEdit  $��2,80,0,0q�$��Right=�%  DevExpress.Xpf.Editors.BaseEdit   NullText$ الايميل��)  #DevExpress.Xpf.Editors.TextEditBase   NullTextForeground �	#89000000	   Text	 �� *Email+
 �� UpdateSourceTrigger$
 PropertyChanged=�{���  �� ElementName$ IsAutoSignup�� �� Path$ 	IsChecked�   ConverterIsEnabled �� 	Converter# [    $��2,10,0,0q�$��Right=�$ الاسم الكامل�� �	#89000000	 �� *
Fullname+$
 PropertyChanged=�{��� $ IsAutoSignup��$ 	IsChecked�# [    $��2,10,0,0q�$��Right=�$ اسم المستخدم�� �	#89000000	 �� *
Username+$
 PropertyChanged=�{��� $ IsAutoSignup��$ 	IsChecked�# [  ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  $��	2,10,0,50q�$��Right=�$ كلمة المرور�� �	#89000000	 �� *
Password+$
 PropertyChanged=�{��� $ IsAutoSignup��$ 	IsChecked�# [  �� -    ��Name$ 
Btn_signup��
 J� Uid$ UserPlus��$��Signup��$"��تسجيل حساب جديد��$��28��  CustomButton#���  $��45.974,0,46.008,0q� � Cursor$
 Hand������ *SignupCommand+{��� $ IsAutoSignup��$ 	IsChecked�# [  �� $��2�����	#FF007ACC$��	0,0.7,0,0q�$ 3��$��0,0.001,0,-0.001q�._��� $��1��.+�&   DevExpress.Xpf.Editors.CheckEdit  -   $��IsAutoSignup��$��103.333,0,0,0q�   Content)  #DevExpress.Xpf.Core.ObjectConverter$* $تفعيل التسجيل الآلي �� -   $��btn_MultiSignup��#���  $��25.118��$��161.333,5,7,10q�$��10(�$
 Hand������ *	Content+$
 PropertyChanged=� �� FallbackValue$ بدأ�� �� *Icon+$
 PropertyChanged=�$
 Play��{��� *	IsChecked+$ IsAutoSignup������ *MultiSignupCommand+$
 PropertyChanged=����� *CommandParam+$
 PropertyChanged=�$ MultiSignup�� �� *CustomButton+��  �� Orientation$ 
Horizontal=�.+��� ���	#FFDE1A1A$��218.333,0,0,0q�$
��9.96��*�� ���	#FFDE1A1A$��
-100,0,0,0q�$
��9.96��*�� $ 
Horizontal=�$��10,0,0,0q�.+�  $	 100��$��4,0,0,0q�$��Right=�$��113.5�� �	#9E000000���	#FF007ACC{��� $ IsAutoSignup��$ 	IsChecked�	 �� *To+$ 2��  $ 0��$��4,0,0,0q�$��Right=�$��95.083�� �	#9E000000���	#FF007ACC{��� $ IsAutoSignup��$ 	IsChecked�	 �� *From+$ 1���� $��	0,8,0,-30q�$��81��.+��� $��WrapWithOverflow=� �� TextAlignment$ Right=�$��73.293��$��14(��� $� �� �� 
���  ��$�*�� �� TextAlignment$ Right=� �� BaselineAlignment$ 	Subscript=�$��Segoe UI Semibold)�$
��Thin"�.� �� $
��Wrap=�$��0,-8,0,0q�$��59.63��$��223.403���� ���	#FF060606$~�x عند تفعيل خيار التسجيل الآلي يجب  وضع فاصل زمني بين كل عملية تسجيل��$ 	Subscript=� �� FlowDirection$ RightToLeft=��� $��0��$��0,0.7q�$ 3�����	#FF007ACC._��� .+��� $��0,2,7,10q�$ Right=�$��14(��� $�تم تسجيل:���� $� ���� $
��Bold"����	#FF2C2C2E��� *Count+$ 0��$
 PropertyChanged=��� $� ���� $�حساب���� $��0,0,7,10q�$ Right=�$��14(��� $!�لم يتم التسجيل:���� $� ���� $
��Bold"����	#FF2C2C2E��� *unregistered+$ 0��$
 PropertyChanged=��� $� ���� $�حساب��%  DevExpress.Xpf.Grid.GridControl  )	  #DevExpress.Xpf.Grid.DataControlBase( 	  !DesignTimeUseDistinctSampleValues .  	  AutoGenerateColumns$ KeepOld=�# 	  EnableSmartColumnsGeneration . $��10,10,1.598,0q� 	  ItemsSource �� *CollectionOfSignup+   Columns $
  DevExpress.Xpf.Grid.GridColumn
  $  DevExpress.Xpf.Grid.BaseColumn   Width$
 auto��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ كلمة المرور��   Binding �� *
Password+
  $
 auto��$ الايميل�� �� *Email+
  $
 auto��$ اسم المستخدم�� �� *
Username+    View  #  DevExpress.Xpf.Grid.TableView  !   AllowPerPixelScrolling! . &   DevExpress.Xpf.Grid.GridViewBase"   ShowGroupPanel" .  #   	AutoWidth# . 