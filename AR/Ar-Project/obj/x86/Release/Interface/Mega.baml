   M S B A M L   `   `   `  ���� A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project      Ar_Project.Mega   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  $localclr-namespace:Ar_Project  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -   $��662.5��$	��938��  � 
ResizeMode$  CanMinimize=� � WindowStartupLocation$ CenterScreen=� � 	Resources  	  coins �� 	UriSource  1463935404_plus  
dollar-bag  eye (1)  eye (2)  eye (3)  eye 1 -font-awesome_4-7-0_print_1024_256_ecf0f1_none 0 ,font-awesome_4-7-0_print_252_143_ecf0f1_none .	 *font-awesome_4-7-0_print_47_28_ecf0f1_none %
 !horizontal-line-remove-button (2) ! horizontal-line-remove-button  	interface  
line-chart 
 locked  	money-bag  oval (1)  oval (2)  oval (3)  oval  pencil-edit-button  plus-symbol  printer (1)  printer (2)  printer (4)  printer (5)  printer (6)  printer  Printerr  profile 	 reply 
 return   settings (1) ! settings " shopping-cart.png # synchronize.png 	$ users % visible (1) & visible (2) ' visible (3) ( visible ) ButtonControlTemplate1 �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value ��Name��%	  &	        &	      &	 H     &	 l     &	 �     &	 �     &	 �     &	 �     &	 3    &		 y    &	
 �    &	 �    &	 /    &	 R    &	 v    &	 �    &	 �    &	 �    &	 �    &	     &	 =    &	 i    &	 �    &	 �    &	 �    &	 �    &	 "    &	 G    &	 h    &	 �    &	 �    &	 �    &	  �    &	!     &	" 2    &	# Y    &	$ ~    &	% �    &	& �    &	' �    &	(     &	) -    �� $ ../images/coins.png?��� $# ../images/1463935404_plus.png?��� $ ../images/dollar-bag.png?��� $ ../images/eye (1).png?��� $ ../images/eye (2).png?��� $ ../images/eye (3).png?��� $ ../images/eye.png?��� $A ;../images/font-awesome_4-7-0_print_1024_256_ecf0f1_none.png?��� $@ :../images/font-awesome_4-7-0_print_252_143_ecf0f1_none.png?��� $> 8../images/font-awesome_4-7-0_print_47_28_ecf0f1_none.png?��� $5 /../images/horizontal-line-remove-button (2).png?��� $1 +../images/horizontal-line-remove-button.png?��� $ ../images/interface.png?��� $ ../images/line-chart.png?��� $ ../images/locked.png?��� $ ../images/money-bag.png?��� $ ../images/oval (1).png?��� $ ../images/oval (2).png?��� $ ../images/oval (3).png?��� $ ../images/oval.png?��� $&  ../images/pencil-edit-button.png?��� $ ../images/plus-symbol.png?��� $ ../images/printer (1).png?��� $ ../images/printer (2).png?��� $ ../images/printer (4).png?��� $ ../images/printer (5).png?��� $ ../images/printer (6).png?��� $ ../images/printer.png?��� $ ../images/Printerr.png?��� $ ../images/profile.png?��� $ ../images/reply.png?��� $ ../images/return.png?��� $  ../images/settings (1).png?��� $ ../images/settings.png?��� $! ../images/shopping-cart.png?��� $ ../images/synchronize.png?��� $ ../images/users.png?��� $ ../images/visible (1).png?��� $ ../images/visible (2).png?��� $ ../images/visible (3).png?��� $ ../images/visible.png?��� " ��.R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$	 border��.g�  $
 0��$ 	#FF474747��  Pressed��  Disabled��.+��� $ border��$��0q����	#FF333333._��� $��Center=�$��Center=�.���  � RowDefinitions �� $
��Auto ���    -   VisualStateGroup��   Transitions %  System.Windows.VisualTransition     GeneratedDuration$ 0D�	   To$ VisualState��   
Storyboard. �� .��T� $ (UIElement.Visibility)�$	 DD��..�i�  R� KeyTime$ 0��  System.Windows.Visibility   Visible R� Value# Z i� $ 0:0:0.1��   Hidden# Z   $ 0D�$ VisualState1��. �� .��T� $ (UIElement.Visibility)�$	 DD��..�i� $ 0��# Z i� $ 0:0:0.1��# Z .   -   VisualState��. �� .��T� $ (UIElement.Visibility)�$	 DD��..�i� $ 0��# Z   -   VisualState1��.+��� ���	#FF817F7F$��1q�$��0.042,13.166,2.75,2.834q�$��2��%  DevExpress.Xpf.Grid.GridControl  -     Name$ DD��$��115.5,1.083,2.771,5.5q�)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration .    AllowColumnMRUFilterList .     IsFilterEnabled .     AllowMRUFilterList .     SelectionMode$
 Cell=�$��1��$y�Hidden=�   Columns $	  DevExpress.Xpf.Grid.GridColumn	  -   $
  DevExpress.Xpf.Grid.BaseColumn 
 Name$
 iddd��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ id��  
  Visible  .  !   Binding! �� *ID+	  -   $ c1��$*��$..\fonts\PFDinTextArabic-Regular.ttf)�$ رقم الفاتورة��" 
  Width$" 90��! �� *NUMF+	  -   $ c2��$ اسم المنتج��! �� *NAME+	  -	   $ c3��$ سعر البيع��! �� *PRICE+	  -
   $ c4��$ سعر التكلفة��! �� *	PRICE_A+	  -   $ c5��$ الباركود��! �� *	BARCODE+	  -   $ c6��$ 
اليوم��$" 80��! �� *DOW+	  -   $ c7��$ تاريخ البيع��$	" 130��#   	SortOrder$# 
Descending=�$   	SortIndex$$ 0��! �� *DAT+%   View% #  DevExpress.Xpf.Grid.TableView  &   AllowPerPixelScrolling& . &   DevExpress.Xpf.Grid.DataViewBase'   ShowTotalSummary' . (   	AutoWidth( . )   AllowEditing) .  &   DevExpress.Xpf.Grid.GridViewBase*   ShowGroupPanel* .    -   $	 DDa��$��115.5,1.083,2.771,5.5q�$
 None=� .  .   .   .  $
 Cell=�$��1�� 	  $ رقم الفاتورة��$" 90��! �� *NUMF+	  $ اسم المنتج��! �� *NAME+	  $ سعر البيع��! �� *PRICE+	  $ سعر التكلفة��! �� *	PRICE_A+	  $ الباركود��! �� *	BARCODE+	  $ 
اليوم��$" 80��! �� *DOW+	  $ تاريخ البيع��$	" 130��$# 
Descending=�$$ 0��! �� *DAT+%   & . ' . ( . ) .  * .    -   $	 DDR��$��115.5,1.083,2.771,5.5q�$
 None=� .  .   .   .  $
 Cell=�$��1�� 	  $ رمز المنتج��$
" auto��+ 	  AllowGrouping]
 YDevExpress.Data.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 
 /DevExpress.Utils.Design.DefaultBooleanConverter$+ False , 
  AllowMoving$, False - 
  AllowResizing$- False .   AllowSorting$. False / 
  Fixed$
/ Left=�0 
  VisibleIndex$0 0��! �� *ID+	  $ اسم العميل��$
" auto��$+ False $, False $- False $. False $
/ Left=�$0 1��! �� *NAME+	  $&  تاريخ اضافة الصنف��$
" auto��$+ False $, False $- False $. False $
/ Left=�$0 2��1   UnboundType8 
 2DevExpress.Utils.Design.UnboundColumnTypeConverter$1 Object ! �� *datrec+	  $$ موعد تسليم الصنف��$
" auto��$+ False $, False $- False $. False $
/ Left=�$0 3��! �� *DAT+	  $ نوع المشكلة��$
" auto��$+ False $, False $- False $. False $
/ Left=�$0 4��! �� *	conprou+	  $ تكلفة الصيانة��$
" auto��$+ False $, False $- False $. False $
/ Left=�$0 5��! �� *PRICE+	  $" رقم هاتف العميل��$
" auto��$+ False $, False $- False $. False $
/ Left=�$0 6��! �� *	discounts+	  $ نوع المنتج��$
" auto��$+ False $, False $- False $. False $
/ Left=�$0 7��! �� *
typeprou+	  $  ��$" 20��$+ False $, False $- False $. False $
/ Left=�$0 8��! �� *isdone+2   EditSettings2 7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings  %   & . ( . ) .  * .  ' . �� -   3 ��Name$3 listBox��$
��Left=�$��0.036,1.333,0,6.096q�$��114.464�����	#FF817F7F$��1,1,1,0q�$��1��.@��� -   4 �� 
IsSelected4 . $��قسم الفواتير��.  (System.Windows.Interactivity.Interaction5   Triggers5 /  )System.Windows.Interactivity.EventTrigger  6   	EventName$6 Selected��.  (System.Windows.Interactivity.TriggerBase7   Actions.7 = 	 7Microsoft.Expression.Interactivity.Core.GoToStateAction  8   	StateName$8 VisualState1���� -   $��Repair��$��قسم الصيانة���� -   $��ListII��$��قسم المبيعات��%  DevExpress.Xpf.Editors.TextEdit  -   $��Encode��$y�Visible=�$
��Left=�%  DevExpress.Xpf.Editors.BaseEdit9   NullText$9 ex:/d,/m,/y��$��1.458,0,0,5.855q�$��Bottom=�$��113.062��$��1������ : �� 
TargetType":  ; �� Triggers; �� < �� Binding< �� = �� ElementName$= Repair��> �� Path$> 
IsSelected�? �� Value? True.a��� @ �� Property@ � y�A �� Value$A Hidden=�  -   $��Encode1��$y�Hidden=�$
��Left=�$9 ex:/d,/m,/y��$��1.458,0,0,5.855q�$��Bottom=�$��108.187��$��1������ ":  ; �� < �� $= Repair��$> 
IsSelected�? True.a��� @ � y�$A Visible=��� -   B ��Name$B ID��$
��Left=�$
��Wrap=�$	��Top=�$��0.957��$��0.307��$y�Hidden=����� *SelectedItem.ID+$= DD���� -   $B id��$
��Left=�$
��Wrap=�$	��Top=�$
��2.75��$
��2.96��$y�Hidden=�  -   $��SearchingBox��$
��Left=�$	��Top=�$&9  بحث برقم الفاتورة��$��112.406��$��1.094,18.145,0,0q�C   MaskType$C RegEx=�D   Mask$D \d{0,9}���� -   $
B Praq��$��Right=�$
��Wrap=�$'��!:مجموع سعر التكلفة��$��Bottom=�$��0,0,5.71,8.336q����	#FF101011$
��Bold"�$��1���� -   $B 	Praq_Copy��$
��Wrap=�$#��:مجموع سعر البيع��$��Bottom=�$��0,0,6.13,23.094q����	#FF101011$
��Bold"�$��Right=�$��1���� -   $B Resultpri_a��$
��Wrap=�$��	SAR  0.00��$��0,0,108.44,8.455q����	#FF3399FF$
��Bold"�$��9.333(�$��Right=�$��Bottom=�$��1���� -   $B 	Resultpri��$
��Wrap=�$��	SAR  0.00��$��0,0,99.117,22.454q����	#FF3399FF$
��Bold"�$��9.333(�$��Right=�$��Bottom=�$��1���� -   E ��Name$E PrivewDoucmentPrinter��$��Right=�$��35.168��$��0,15.64,3.754,-0.098q���Z� ��Z� .���� $.��(/Pascal;component/images/Print_16x16.png��$��Uniform=��� -   $E Delete��$��Right=�$��35.168��$��0,15.552,39.336,-0.125q���Z� ��Z� .���� $/��)/Pascal;component/images/Delete_32x32.png��$��Uniform=�