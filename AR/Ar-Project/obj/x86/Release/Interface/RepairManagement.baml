   M S B A M L   `   `   `  ���� 
  Pascal+    %Ar_Project.Interface.RepairManagement   j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid     � Title$  RepairManagement��$	��656��$��690.385��"  DevExpress.Xpf.Core.DXWindow   
IsAeroMode .   � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=�.���  � ColumnDefinitions �� -    �Name$ A1��$
��363* ��� -   $ A2��$��0* ��� $
��144* ��� $
��158* ��� $	��19* � � RowDefinitions �� $��71 ��� $��83 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��22 ��� $
��21.5 ��� $��124.5 �.+�+  %DevExpress.Xpf.LayoutControl.GroupBox  -     Name$
 Aadd��$��5��$��14��$��
0,22,0,2.5q�,  &DevExpress.Xpf.Core.ContentControlBase	   Content.	 �  �� $��4* ��� $
��162* ��� $	��73* ��� $
��205* ��� $��0 � �� $��32 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��1 ��� $��1 ��� $��0 ��� $��0 ��� $��0 ��� $	��110 ��� $��15 ��� $��32 �.+��� -   
 ��Name$
 Btn_Add��$��
اضافة��$��14��$��3��$��1,2,0,6q�%  DevExpress.Xpf.Editors.TextEdit  -     Name$ price��$��3��   
CaretIndex$ 3��$��Right=�$��3��%  DevExpress.Xpf.Editors.BaseEdit   NullText$ 
السعر��   MaskType$ Numeric=�  -   $
 name��$��1��$ 2��$��Right=�$��1��$ اسم العميل��$��2��  -   $��content_Prou��$��12��$��3��$��Right=�$��1��$ وصف المشكلة��)  #DevExpress.Xpf.Editors.TextEditBase   TextWrapping$
 Wrap=�%  DevExpress.Xpf.Editors.DateEdit  -   $
��date��$��3��$ 4��$��Right=�$��1��$&  تاريخ تسليم الطلب��$��2��   Mask$ 
dd/mm/yyyy��  -	   $
 KIND��$��5��$ 5��$��Right=�$��3��$$ نوع الصنف المضاف��  -
   $ 	discounts��$��5��$ 6��$��Right=�$2 ,(رقم هاتف العميل(اختياري��$��1��$��2��  -   $ ID��$ 1��$��1��$��Right=�$��3��{�.  $ ترميز الطلب��/  )DevExpress.Xpf.Editors.ListBoxRadioButton  -     Name$ 
UnComplete��$'��!لم يتم تسليم الطلب��$��1��$
��Left=�$	��100��$��0,0,-130,-100q�$��14��$��Stretch=�$
��Auto�� d� 	IsChecked$
 TrueY�  -   $ 
IsComplete��$ ��تم تسليم الطلب��$��1��$
��Left=�$	��100��$��0 ,-50,-100,-100q�$��15��$��Stretch=�$
��Auto��  -   $
 addd��$��14��$��5��$��
0,0,0,-132q�.	 %	  DevExpress.Xpf.Grid.GridControl	  -   $��Data_Add��)
  #DevExpress.Xpf.Grid.DataControlBase 
  AutoGenerateColumns$
 None=�# 
  EnableSmartColumnsGeneration . $y�Visible=� 
  AllowColumnMRUFilterList .   
  IsFilterEnabled .   
  AllowMRUFilterList .   
  SelectionMode$
 Cell=� 	  Columns $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ رمز المنتج��$  DevExpress.Xpf.Grid.BaseColumn   Width$
 auto��   AllowGrouping]	 YDevExpress.Data.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False    AllowMoving$ False    AllowResizing$ False    AllowSorting$ False     Fixed$
  Left=�!   VisibleIndex$! 0��"   Binding" �� *ID+  $ اسم العميل��$
 auto��$ False $ False $ False $ False $
  Left=�$! 1��" �� *NAME+  $&  تاريخ اضافة الصنف��$
 auto��$ False $ False $ False $ False $
  Left=�$! 2��#   UnboundType8 	 2DevExpress.Utils.Design.UnboundColumnTypeConverter$# Object " �� *DAT+  $$ موعد تسليم الصنف��$
 auto��$ False $ False $ False $ False $
  Left=�$! 3��" �� *datrec+  $ نوع المشكلة��$
 auto��$ False $ False $ False $ False $
  Left=�$! 4��" �� *
typeprou+  $ تكلفة الصيانة��$
 auto��$ False $ False $ False $ False $
  Left=�$! 5��" �� *PRICE+  $" رقم هاتف العميل��$
 auto��$ False $ False $ False $ False $
  Left=�$! 6��" �� *	discounts+  $ نوع المنتج��$
 auto��$ False $ False $ False $ False $
  Left=�$! 7��" �� *	conprou+$ 	  View$ #  DevExpress.Xpf.Grid.TableView  %   AllowPerPixelScrolling% . &   DevExpress.Xpf.Grid.DataViewBase&   ShowTotalSummary& .  '   	AutoWidth' . (   AllowEditing( .  &   DevExpress.Xpf.Grid.GridViewBase)   ShowGroupPanel) .    -   $ A3��$y�Hidden=�$��5��$��14��$��
0,22,0,2.5q�.	 �  �� $��4* ��� $
��162* ��� $	��73* ��� $
��205* ��� $��0 � �� $��32 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��22 ��� $��10 ��� $��1 ��� $��1 ��� $��0 ��� $��0 ��� $��0 ��� $	��110 ��� $��15 ��� $��32 �.+��� -   $
 Btn_Edit��$��
تعديل��$��14��$��3��$��1,2,0,6q�  -   $ 
price_edit��$��3��$ 3��$��Right=�$��3��$ 
السعر��*   Text* �� *SelectedItem.PRICE++ �� ElementName$+ 	Data_Edit��  -   $ 	name_edit��$��1��$ 2��$��Right=�$��1��$ اسم الطلب��$��2��* �� *SelectedItem.NAME+$+ 	Data_Edit��  -   $ content_Prou_edit��$��12��$��3��$��Right=�$��1��$ وصف المشكلة��$
 Wrap=�* �� *SelectedItem.conprou+$+ 	Data_Edit��  -   ,  Name$, 	date_edit��$��3��$ 4��$��Right=�$��1��$ 
dd/mm/yyyy��$&  تاريخ تسليم الطلب��$��2��* �� *SelectedItem.datrec+$+ 	Data_Edit��  -   $ 	KIND_EDIT��$��5��$ 5��$��Right=�$��3��$$ نوع الصنف المضاف��* �� *SelectedItem.typeprou+$+ 	Data_Edit��  -   $ discounts_Edit��$��5��$ 6��$��Right=�$2 ,(رقم هاتف العميل(اختياري��$��1��$��2��* �� *SelectedItem.discounts+$+ 	Data_Edit��  -   $	 ID1��$ 1��$��1��$��Right=�$��3��{�.  $ ترميز الطلب��* �� *SelectedItem.ID+$+ 	Data_Edit��  -   $ UnComplete_edit��$'��!لم يتم تسليم الطلب��$��1��$
��Left=�$	��100��$��0,0,-130,-100q�$��14��$��Stretch=�$
��Auto������ - �� 
TargetType"-  .��� . �� Property. �@d�	IsChecked/ �� Value$/ FalseY�0 �� Triggers0 �� 1 �� Binding1 �� *SelectedItem.isdone+$+ 	Data_Edit��2 �� Value2 True.a��� . �@d�	IsChecked$
/ TrueY�  -   $ IsComplete_edit��$ ��تم تسليم الطلب��$��1��$
��Left=�$	��100��$��0 ,-50,-100,-100q�$��15��$��Stretch=�$
��Auto������ "-  .��� . �@d�	IsChecked$
/ TrueY�0 �� 1 �� *SelectedItem.isdone+$+ 	Data_Edit��2 True.a��� . �@d�	IsChecked$/ FalseY�  -   $ A4��$��14��$y�Hidden=�$��5��$��
0,0,0,-132q�.	 	  -   3 	 Name$3 	Data_Edit��$
 None=� . $y�Visible=� .   .   .  $
 Cell=�   $ رمز المنتج��$
 auto��$ False $ False $ False $ False $
  Left=�$! 0��" �� *ID+  $ اسم العميل��$
 auto��$ False $ False $ False $ False $
  Left=�$! 1��" �� *NAME+  $&  تاريخ اضافة الصنف��$
 auto��$ False $ False $ False $ False $
  Left=�$! 2��$# Object " �� *DAT+  $$ موعد تسليم الصنف��$
 auto��$ False $ False $ False $ False $
  Left=�$! 3��" �� *datrec+  $ نوع المشكلة��$
 auto��$ False $ False $ False $ False $
  Left=�$! 4��" �� *	conprou+  $ تكلفة الصيانة��$
 auto��$ False $ False $ False $ False $
  Left=�$! 5��" �� *PRICE+  $" رقم هاتف العميل��$
 auto��$ False $ False $ False $ False $
  Left=�$! 6��" �� *	discounts+  $ نوع المنتج��$
 auto��$ False $ False $ False $ False $
  Left=�$! 7��" �� *
typeprou+$   % . & .  ' . ( .  ) .  