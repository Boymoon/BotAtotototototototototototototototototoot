   M S B A M L   `   `   `  ����  Shannon+    %Ar_Project.Interface.RepairManagement   5      j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6B   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   6�     � Title$  RepairManagement��5      $	��656��6   $��690.385��6+   "  DevExpress.Xpf.Core.DXWindow   
IsAeroMode .   � WindowStartupLocation$ CenterScreen=�6N    � WindowStyle$ 
ToolWindow=�6s    � 
ResizeMode$ NoResize=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��152* �6   �� 5      $
��195* �6   �� 5      $
��108* �6   �� 5      $	��13* �6    � RowDefinitions 5   
   �� 5      $	��154 �6   �� 5      $��22 �6   �� 5      $��10 �6   �� 5      $��22 �6   �� 5      $��10 �6   �� 5      $��22 �6   �� 5      $��10 �6   �� 5      $��22 �6   �� 5      $��10 �6   �� 5      $��22 �6   �� 5      $��10 �6   �� 5      $��22 �6   �� 5      $
��21.5 �6   �� 5       $��124.5 �6   .+�5)   
   +  %DevExpress.Xpf.LayoutControl.GroupBox  $��4��6   $��13��6,   $��
0,22,0,2.5q�6>   ,  &DevExpress.Xpf.Core.ContentControlBase   Content. 5*      �  5+      �� 5,      $��4* �6'   �� 5-      $
��162* �6'   �� 5.      $	��73* �6'   �� 5/      $
��205* �6'   �� 50      $��0 �6'    5B      �� 5C      $��32 �6$   �� 5D      $��22 �6$   �� 5E      $��10 �6$   �� 5F      $��22 �6$   �� 5G      $��10 �6$   �� 5H      $��22 �6$   �� 5I      $��10 �6$   �� 5J      $��1 �6$   �� 5K      $��1 �6$   �� 5L      $��0 �6$   �� 5M      $��0 �6$   �� 5N      $��0 �6$   �� 5O      $	��110 �6$   �� 5P      $��15 �6$   �� 5Q      $��32 �6$   .+�5T      �� -   5         ��Name$ Btn_Add��5T      $��
اضافة��6@   $��14��6Q   $��3��6_   $��1,2,0,6q�6o   %  DevExpress.Xpf.Editors.TextEdit  5]      -   5        	  Name$	 price��5]   ;   $��3��6   
   
CaretIndex$
 3��6,   $��Right=�6J   $��3��6m   %  DevExpress.Xpf.Editors.BaseEdit   NullText$ 
السعر��6~     5^      -   5        $
	 name��5^   =   $��1��6   $
 2��6.   $��Right=�6K   $��1��6n   $ اسم الطلب��6   $��2��6�     5_      -   5        $��content_Prou��5_   -   $��12��6   $��3��6A   $��Right=�6U   $��1��6z   $ وصف المشكلة��6�   )  #DevExpress.Xpf.Editors.TextEditBase   TextWrapping$
 Wrap=�6�   %  DevExpress.Xpf.Editors.DateEdit  5`      -   5        $
��date��5`   ,   $��3��6   $
 4��68   $��Right=�6G   $��1��6j   $&  تاريخ تسليم الطلب��6z   $��2��6�   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5a      -   5          Name$ type_cou��5a   0   $��5��6#   $
 5��6B   $��Right=�6Q   $��3��6t   $$ نوع الصنف المضاف��6�   '	  !DevExpress.Xpf.Editors.ButtonEdit 	  IsTextEditable$
 TrueX�6�   +
  %DevExpress.Xpf.Editors.LookUpEditBase 
  AutoComplete .     StyleSettings 5b      2  ,DevExpress.Xpf.Editors.ComboBoxStyleSettings  5c      5h        5i      -   5        $	 	discounts��5i   r   $��5��6   $
 6��6-   $��Right=�6<   $ % الخصم��6_   $��2��6�     5j      -   5        $	 Finally_Price��5j   s   $��5��6   $
 6��6-   $��Right=�6<   $ SAR 0.00��6_   {�.  $��1��6�     5o      -	   5        $	 ID��5o   n   $
 1��6   $��1��6.   $��Right=�6;   $��3��6^   {�.  $ ترميز الطلب��6�   5p      5t        5v   
   $��13��6   $��4��6&   $��
0,0,0,-132q�6:   . 5w      %  DevExpress.Xpf.Grid.GridControl  -
   5        $��Data_Add��5w   9   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6   #   EnableSmartColumnsGeneration . $y�Visible=�6n      AllowColumnMRUFilterList .     IsFilterEnabled .     AllowMRUFilterList .     SelectionMode$
 Cell=�6�      Columns 5x      $  DevExpress.Xpf.Grid.GridColumn  5y      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ رمز المنتج��6%   $  DevExpress.Xpf.Grid.BaseColumn   Width$
 auto��6S      AllowGrouping]	 YDevExpress.Data.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6`      AllowMoving$ False 6v      AllowResizing$ False 6�      AllowSorting$ False 6�      Fixed$
 Left=�6�      VisibleIndex$ 0��6�       Binding  6<   �� *ID+6�     5z      $ اسم المنتج��6%   $
 auto��6U   $ False 6b   $ False 6x   $ False 6�   $ False 6�   $
 Left=�6�   $ 1��6�     6<   �� *NAME+6�     5{      $&  تاريخ اضافة الصنف��6%   $
 auto��6[   $ False 6h   $ False 6~   $ False 6�   $ False 6�   $
 Left=�6�   $ 2��6�   !   UnboundType8 	 2DevExpress.Utils.Design.UnboundColumnTypeConverter$! Object 6�     6C   �� *DAT+6�     5|      $$ موعد تسليم الصنف��6%   $
 auto��6]   $ False 6j   $ False 6�   $ False 6�   $ False 6�   $
 Left=�6�   $ 3��6�     6B   �� *datrec+6�     5}      $ نوع المشكلة��6%   $
 auto��6Y   $ False 6f   $ False 6|   $ False 6�   $ False 6�   $
 Left=�6�   $ 4��6�     6=   �� *	conprou+6�     5~      $ تكلفة الصيانة��6%   $
 auto��6Y   $ False 6f   $ False 6|   $ False 6�   $ False 6�   $
 Left=�6�   $ 5��6�     6?   �� *PRICE+6�     5      $ % الخصم��6%   $
 auto��6W   $ False 6d   $ False 6z   $ False 6�   $ False 6�   $
 Left=�6�   $ 6��6�     69   �� *	discounts+6�     5�      $ الاجمالي��6%   $
 auto��6W   $ False 6d   $ False 6z   $ False 6�   $ False 6�   $
 Left=�6�   $ 7��6�     6:   �� *
typeprou+6�     5�      $ حالة��6%   $
 auto��6Q   $ False 6^   $ False 6t   $ False 6�   $ False 6�   $
 Left=�6�   $ 8��6�     66   �� *isdone+6�   "   View" 5�      #  DevExpress.Xpf.Grid.TableView  5�      #   AllowPerPixelScrolling# . &   DevExpress.Xpf.Grid.DataViewBase$   ShowTotalSummary$ . %   	AutoWidth% . &   AllowEditing& .  &   DevExpress.Xpf.Grid.GridViewBase'   ShowGroupPanel' .  6�   5�      5�      5�      5�      