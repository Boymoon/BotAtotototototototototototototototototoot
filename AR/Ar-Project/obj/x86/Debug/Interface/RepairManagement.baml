   M S B A M L   `   `   `  ����
  Pascal+    %Ar_Project.Interface.RepairManagement   5      j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6B   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   6�     � Title$  RepairManagement��5      $	��656��6   $��690.385��6+   "  DevExpress.Xpf.Core.DXWindow   
IsAeroMode .   � WindowStartupLocation$ CenterScreen=�6N    � WindowStyle$ 
ToolWindow=�6s    � 
ResizeMode$ NoResize=�6�   .��5      �  � ColumnDefinitions 5   
    � RowDefinitions 5   
   �� 5      �� 5      $	��200 �6   .+�5   
   +  %DevExpress.Xpf.LayoutControl.GroupBox  -   5          Name$
 Aadd��5      $��5��6&   $��
0,22,0,2.5q�6;   ,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5      �  5      �� 5      $��4* �6'   �� 5      $
��162* �6'   �� 5      $	��73* �6'   �� 5       $
��205* �6'   �� 5!      $��0 �6'    54      �� 55      $��22 �6$   �� 56      $��22 �6%   �� 57      $��22 �6$   �� 58      $��22 �6%   �� 59      $��22 �6$   �� 5:      $��22 �6%   �� 5;      $��22 �6$   �� 5<      �� 5=      $��* �6$   .+�5@      �� -   5        	 ��Name$	 Btn_Add��5@      $��
اضافة��6@   $��8��6Q   $��3��6^   $��1,2,0,6q�6o   %  DevExpress.Xpf.Editors.TextEdit  5H      -   5        
  Name$
 price��5H   ;   $��3��6      
CaretIndex$ 3��6,   $��Right=�6J   $��3��6m   %  DevExpress.Xpf.Editors.BaseEdit   NullText$ 
السعر��6~      MaskType$ Numeric=�6�     5I      -   5        $

 name��5I   =   $��1��6   $ 2��6.   $��Right=�6K   $��1��6n   $ اسم العميل��6   $��2��6�     5J      -   5        $��content_Prou��5J   ,   $��7��6   $��3��6@   $��Right=�6T   $��1��6y   $ وصف المشكلة��6�   )  #DevExpress.Xpf.Editors.TextEditBase   TextWrapping$
 Wrap=�6�   $��0,0,0,2q�6�   %  DevExpress.Xpf.Editors.DateEdit  5K      -   5        $
��date��5K   ,   $��3��6   $ 4��68   $��Right=�6G   $��1��6j   $&  تاريخ تسليم الطلب��6z   $��2��6�      Mask$ 
dd/mm/yyyy��6�     5L      -   5        $

 KIND��5L   ,   $��5��6   $ 5��6:   $��Right=�6I   $��3��6l   $$ نوع الصنف المضاف��6|   5M        5N      -   5        $
 	discounts��5N   �   $��5��6   $ 6��6-   $��Right=�6<   $2 ,(رقم هاتف العميل(اختياري��6_   $��1��6�   $��2��6�     5T      -	   5        $
 ID��5T   n   $ 1��6   $��1��6.   $��Right=�6;   $��3��6^   {�.  $ ترميز الطلب��6�     5U      $��8��6    $��1��6-   4  .DevExpress.Xpf.Core.HeaderedContentControlBase   Header$ حالة الطلب��6>   $��2��6R   $��0,0,34.952,0q�6f   $
��Left=�6|   . 5V      � $��5,0,0,0q�6    5W      �� 5X      �� 5Y      .+�5\      /	  )DevExpress.Xpf.Editors.ListBoxRadioButton	  -
   5         	 Name$ 
UnComplete��5\   R   $��1��61   $��	0,-50,0,0q�6>   $'��!لم يتم تسليم الطلب��6f   $
��Left=�6�   $��Stretch=�6�   $
��Auto��6�    d� 	IsChecked$
 TrueY�6�   	  5]      -   5        $ 
IsComplete��5]   O   $��2��61   $��0,5,0,0q�6>   $ ��تم تسليم الطلب��6c   $
��Left=�6   $��Stretch=�6�   $��187.949��6�   5^      5_      5a      5e        5g   
   -   5        $
 addd��5g      $��14��6&   $��5��64   . 5h      %
  DevExpress.Xpf.Grid.GridControl
  -   5        $��Data_Add��5h   9   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6   #   EnableSmartColumnsGeneration . $y�Visible=�6n      AllowColumnMRUFilterList .     IsFilterEnabled .     AllowMRUFilterList .     SelectionMode$
 Cell=�6�    
  Columns 5i      $  DevExpress.Xpf.Grid.GridColumn  5j      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ رمز المنتج��6%   $  DevExpress.Xpf.Grid.BaseColumn   Width$
 auto��6S      AllowGrouping]	 YDevExpress.Data.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6`      AllowMoving$ False 6v      AllowResizing$ False 6�      AllowSorting$ False 6�       Fixed$
  Left=�6�   !   VisibleIndex$! 0��6�   "   Binding" 6<   �� *ID+6�     5k      $ اسم العميل��6%   $
 auto��6U   $ False 6b   $ False 6x   $ False 6�   $ False 6�   $
  Left=�6�   $! 1��6�   " 6<   �� *NAME+6�     5l      $&  تاريخ اضافة الصنف��6%   $
 auto��6[   $ False 6h   $ False 6~   $ False 6�   $ False 6�   $
  Left=�6�   $! 2��6�   #   UnboundType8 	 2DevExpress.Utils.Design.UnboundColumnTypeConverter$# Object 6�   " 6C   �� *DAT+6�     5m      $$ موعد تسليم الصنف��6%   $
 auto��6]   $ False 6j   $ False 6�   $ False 6�   $ False 6�   $
  Left=�6�   $! 3��6�   " 6B   �� *datrec+6�     5n      $ نوع المشكلة��6%   $
 auto��6Z   $ False 6g   $ False 6}   $ False 6�   $ False 6�   $
  Left=�6�   $! 4��6�   " 6=   �� *
typeprou+6�     5o      $ تكلفة الصيانة��6%   $
 auto��6Y   $ False 6f   $ False 6|   $ False 6�   $ False 6�   $
  Left=�6�   $! 5��6�   " 6?   �� *PRICE+6�     5p      $" رقم هاتف العميل��6%   $
 auto��6_   $ False 6l   $ False 6�   $ False 6�   $ False 6�   $
  Left=�6�   $! 6��6�   " 6A   �� *	discounts+6�     5q      $ نوع المنتج��6%   $
 auto��6X   $ False 6e   $ False 6{   $ False 6�   $ False 6�   $
  Left=�6�   $! 7��6�   " 6<   �� *	conprou+6�   $ 
  View$ 5v      #  DevExpress.Xpf.Grid.TableView  5w      %   AllowPerPixelScrolling% . &   DevExpress.Xpf.Grid.DataViewBase&   ShowTotalSummary& .  '   	AutoWidth' . (   AllowEditing( .  &   DevExpress.Xpf.Grid.GridViewBase)   ShowGroupPanel) .  6�   5y      5z        5{   
   -   5        $ A3��5{      $y�Hidden=�6$   $��5��68   $��14��6L   $��
0,22,0,2.5q�6^   . 5|      � .+�5�      �� -   5        $	 Btn_Edit��5�      $��
تعديل��6E   $��14��6V   $��3��6d   $��1,2,0,6q�6t     5�      -   5        $
 
price_edit��5�   ;   $��3��6   $ 3��6,   $��Right=�6O   $��3��6r   $ 
السعر��6�   *   Text* 6�   �� *SelectedItem.PRICE++ �� ElementName$+ 	Data_Edit��6�     5�      -   5        $
 	name_edit��5�   =   $��1��6   $ 2��6.   $��Right=�6P   $��1��6s   $ اسم الطلب��6�   $��2��6�   * 6�   �� *SelectedItem.NAME+$+ 	Data_Edit��6�     5�      -   5        $
 content_Prou_edit��5�   -   $��12��6   $��3��6H   $��Right=�6\   $��1��6�   $ وصف المشكلة��6�   $
 Wrap=�6�   * 6�   �� *SelectedItem.conprou+$+ 	Data_Edit��6�     5�      -   5        ,  Name$, 	date_edit��5�   ,   $��3��6   $ 4��6?   $��Right=�6N   $��1��6q   $ 
dd/mm/yyyy��6�   $&  تاريخ تسليم الطلب��6�   $��2��6�   * 6�   �� *SelectedItem.datrec+$+ 	Data_Edit��6�     5�      -   5        $
 	KIND_EDIT��5�   ,   $��5��6   $ 5��6?   $��Right=�6N   $��3��6s   $$ نوع الصنف المضاف��6�   * 6�   �� *SelectedItem.typeprou+$+ 	Data_Edit��5�        5�      -   5        $
 discounts_Edit��5�   �   $��5��6   $ 6��6-   $��Right=�6<   $2 ,(رقم هاتف العميل(اختياري��6�   $��1��6�   $��2��6�   * 6_   �� *SelectedItem.discounts+$+ 	Data_Edit��6�     5�      -   5        $	
 ID1��5�   n   $ 1��6   $��1��6.   $��Right=�6;   $��3��6^   {�.  $ ترميز الطلب��6�   * 6|   �� *SelectedItem.ID+$+ 	Data_Edit��6�   	  5�      -   5        $ UnComplete_edit��5�   )   $'��!لم يتم تسليم الطلب��6C   $��1��6`   $
��Left=�6u   $	��100��6�   $��0,0,-130,-100q�6�   $��14��6�   $��Stretch=�6�   $
��Auto��6�   ��5�      �� 5�      - �� 
TargetType"- 	 6    .�5�      �� . �� Property. �@d�	IsChecked/ �� Value$/ FalseY�6:   6J   0 �� Triggers0 5�      �� 5�   "   1 �� Binding1 6.   �� *SelectedItem.isdone+$+ 	Data_Edit��2 �� Value2 True6l   .a�5�   &   �� . �@d�	IsChecked$
/ TrueY�6B   5�   #   5�      5�      	  5�      -   5        $ IsComplete_edit��5�   )   $ ��تم تسليم الطلب��6B   $��1��6[   $
��Left=�6q   $	��100��6�   $��0 ,-50,-100,-100q�6�   $��15��6�   $��Stretch=�6�   $
��Auto��6�   ��5�      �� 5�      "- 	 6    .�5�      �� . �@d�	IsChecked$
/ TrueY�6:   6I   0 5�      �� 5�   "   1 6.   �� *SelectedItem.isdone+$+ 	Data_Edit��2 True6l   .a�5�   &   �� . �@d�	IsChecked$/ FalseY�6B   5�   #   5�      5�      5�      5�        5�   
   -   5        $ A4��5�      $��14��6$   $y�Hidden=�62   $��5��6F   $��
0,0,0,-132q�6Z   . 5�      
  -   5        3 
 Name$3 	Data_Edit��5�   9   $
 None=�6    . $y�Visible=�6q    .   .   .  $
 Cell=�6�    5�        5�      $ رمز المنتج��6%   $
 auto��6S   $ False 6`   $ False 6v   $ False 6�   $ False 6�   $
  Left=�6�   $! 0��6�   " 6<   �� *ID+6�     5�      $ اسم العميل��6%   $
 auto��6U   $ False 6b   $ False 6x   $ False 6�   $ False 6�   $
  Left=�6�   $! 1��6�   " 6<   �� *NAME+6�     5�      $&  تاريخ اضافة الصنف��6%   $
 auto��6[   $ False 6h   $ False 6~   $ False 6�   $ False 6�   $
  Left=�6�   $! 2��6�   $# Object 6�   " 6C   �� *DAT+6�     5�      $$ موعد تسليم الصنف��6%   $
 auto��6]   $ False 6j   $ False 6�   $ False 6�   $ False 6�   $
  Left=�6�   $! 3��6�   " 6B   �� *datrec+6�     5�      $ نوع المشكلة��6%   $
 auto��6Y   $ False 6f   $ False 6|   $ False 6�   $ False 6�   $
  Left=�6�   $! 4��6�   " 6=   �� *	conprou+6�     5�      $ تكلفة الصيانة��6%   $
 auto��6Y   $ False 6f   $ False 6|   $ False 6�   $ False 6�   $
  Left=�6�   $! 5��6�   " 6?   �� *PRICE+6�     5�      $" رقم هاتف العميل��6%   $
 auto��6_   $ False 6l   $ False 6�   $ False 6�   $ False 6�   $
  Left=�6�   $! 6��6�   " 6A   �� *	discounts+6�     5�      $ نوع المنتج��6%   $
 auto��6Z   $ False 6g   $ False 6}   $ False 6�   $ False 6�   $
  Left=�6�   $! 7��6�   " 6<   �� *
typeprou+6�   $ 5�        5�      % . & .  ' . ( .  ) .  6�   5�      5�      5�      5�      