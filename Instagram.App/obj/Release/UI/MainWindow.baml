   M S B A M L   `   `   `  ���� H  DInstagram.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Instagram.AppInstagram.App  3clr-namespace:Instagram.App.UIInstagram.App.UI      Instagram.App.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  'localclr-namespace:Instagram.App  j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  f bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 )UIclr-namespace:Instagram.App.UI  	   � Title$%  الواجهة الرئيسية��$	��596��$��936.282�� � WindowStartupLocation$ CenterScreen=�
�������"  DevExpress.Xpf.Core.DXWindow   
IsAeroMode .   � 	Resources "   Instagram.App.LoginConverter   LoginConverter   BooleanToVisibilityConverter��%   &	        &	        �� .��� .+�&   DevExpress.Xpf.Core.DXTabControl     View .  (DevExpress.Xpf.Core.TabControlScrollView  ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$	 Top=�   HeaderOrientation$ 
Horizontal=�   NewButtonShowMode$ NoWhere=�   RemoveTabItemsOnHiding .  .@�#  DevExpress.Xpf.Core.DXTabItem  �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]	   Header$	 الحسابات��.��  .@�  $	 اضافة حسابات��
   VisibleInHeaderMenu
 . .���  � ColumnDefinitions �� �� $	��259 �.+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $	��260��$��1��.	  (DevExpress.Xpf.LayoutControl.LayoutGroup 	  Orientation$ Vertical=�$	��260��.+�	  $ Vertical=� 	  Header$ اضافة حساب�� 	  View$ GroupBox=�.+�-
  'DevExpress.Xpf.LayoutControl.LayoutItem
   
  LabelPosition$	 Top=� 
  Label$ اسم المستخدم�� 
  Content. %  DevExpress.Xpf.Editors.TextEdit  )  #DevExpress.Xpf.Editors.TextEditBase   Text �� *ModelMainWindow.Username+
  $	 Top=�$ كلمة المرور��. ,  &DevExpress.Xpf.Editors.PasswordBoxEdit   �� *ModelMainWindow.Password+	  $ 
Horizontal=�$��0,8,0,0q�.+�
  $��23��$	��104��$��	-27,0,0,0q�. �� $��استيراد��  CustomButton#���  
 J� Uid$ users��$
��Left=�$
��Left=�$��27,0,0,0q�$��70�� � Cursor$
 Hand��$��Import������ *&$ModelMainWindow.ImportaccountCommand+
  $��23��. �� $��اضافة حساب��#���  $ userplus��$
 Hand��$	��Add������ *$"ModelMainWindow.AddaccountsCommand+% 	 DevExpress.Xpf.Grid.GridControl  )  #DevExpress.Xpf.Grid.DataControlBase(   !DesignTimeUseDistinctSampleValues .    AutoGenerateColumns$ KeepOld=�#   EnableSmartColumnsGeneration .    ItemsSource �� *	Accounts_+   Columns $ 	 DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ اسم المستخدم��   Binding �� *
Username+  $ كلمة المرور�� �� *
Password+   View # 	 DevExpress.Xpf.Grid.TableView     	AutoWidth . & 	  DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase    ShowTotalSummary  .   $	 تسجيل الدخول��.���  �� �� $	��259 �.+�  $	��260��$��1��$ Vertical=�$	��260��.+�	  $ Vertical=�$ اضافة حساب��$ GroupBox=�y��� *ModelMainWindow.IsLogedin+! �� UpdateSourceTrigger$! PropertyChanged=�" �� 	Converter#" [  .+�
  $	 Top=�$ اسم المستخدم��.    �� *ModelMainWindow.Username+$! PropertyChanged=�
  $	 Top=�$ كلمة المرور��.    �� *ModelMainWindow.Password+$! PropertyChanged=�	  $ 
Horizontal=�$��0,8,0,0q�.+�
  $��23��. �� $��تسجيل الدخول��#���  $ Signin��$
 Hand��$	��Add������ *ModelMainWindow.SigninCommand+
  y��� *ModelMainWindow.IsLogedin+#" [ .    Instagram.App.UI.Logedin  -   #  Name$# Logedin��  -   $  Name$$ gridc�� . $ KeepOld=� . %   SelectedItem% �� *ModelMainWindow+ �� *	Accounts_+   $ اسم المستخدم�� �� *
Username+  $ كلمة المرور�� �� *
Password+    .  .   .   .   $		 Tab��.��� 
������ 