   M S B A M L   `   `   `  ����A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project  5   	       Ar_Project.Mega   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   $localclr-namespace:Ar_Project  5   	   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   6H   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6�   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6�   h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 6%  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6j  -   5        $��662.5��5   	   $	��938��6     � 
ResizeMode$  CanMinimize=�6%    � WindowStartupLocation$ CenterScreen=�6>    � 	Resources 5	       	  coins �� 	UriSource  1463935404_plus  
dollar-bag  eye (1)  eye (2)  eye (3)  eye 1 -font-awesome_4-7-0_print_1024_256_ecf0f1_none 0 ,font-awesome_4-7-0_print_252_143_ecf0f1_none .	 *font-awesome_4-7-0_print_47_28_ecf0f1_none %
 !horizontal-line-remove-button (2) ! horizontal-line-remove-button  	interface  
line-chart 
 locked  	money-bag  oval (1)  oval (2)  oval (3)  oval  pencil-edit-button  plus-symbol  printer (1)  printer (2)  printer (4)  printer (5)  printer (6)  printer  Printerr  profile 	 reply 
 return   settings (1) ! settings " shopping-cart.png # synchronize.png 	$ users % visible (1) & visible (2) ' visible (3) ( visible ) ButtonControlTemplate1 �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value ��Name��%�  &	        &	 2     &	 n     &	 �     &	 �     &	     &	 A    &	 q    &	 �    &		 $    &	
 {    &	 �    &	     &	 I    &	 �    &	 �    &	 �    &	     &	 S    &	 �    &	 �    &	 �    &	 0    &	 h    &	 �    &	 �    &	     &	 H    &	 |    &	 �    &	 �    &	     &	  J    &	! �    &	" �    &	# �    &	$ *    &	% \    &	& �    &	' �    &	( 	    &	) 8	    �� 5
   
   $ ../images/coins.png?�6$   6F   �� 5   
   $# ../images/1463935404_plus.png?�6.   6Z   �� 5   
   $ ../images/dollar-bag.png?�6)   6P   �� 5   
   $ ../images/eye (1).png?�6&   6J   �� 5   
   $ ../images/eye (2).png?�6&   6J   �� 5   
   $ ../images/eye (3).png?�6&   6J   �� 5   
   $ ../images/eye.png?�6"   6B   �� 5   
   $A ;../images/font-awesome_4-7-0_print_1024_256_ecf0f1_none.png?�6L   6�   �� 5   
   $@ :../images/font-awesome_4-7-0_print_252_143_ecf0f1_none.png?�6K   6�   �� 5   
   $> 8../images/font-awesome_4-7-0_print_47_28_ecf0f1_none.png?�6I   6�   �� 5   
   $5 /../images/horizontal-line-remove-button (2).png?�6@   6~   �� 5   
   $1 +../images/horizontal-line-remove-button.png?�6<   6v   �� 5   
   $ ../images/interface.png?�6(   6N   �� 5   
   $ ../images/line-chart.png?�6)   6P   �� 5   
   $ ../images/locked.png?�6%   6H   �� 5   
   $ ../images/money-bag.png?�6(   6N   �� 5   
   $ ../images/oval (1).png?�6'   6L   �� 5   
   $ ../images/oval (2).png?�6'   6L   �� 5   
   $ ../images/oval (3).png?�6'   6L   �� 5   
   $ ../images/oval.png?�6#   6D   �� 5   
   $&  ../images/pencil-edit-button.png?�61   6`   �� 5   
   $ ../images/plus-symbol.png?�6*   6R   �� 5    
   $ ../images/printer (1).png?�6*   6R   �� 5!   
   $ ../images/printer (2).png?�6*   6R   �� 5"   
   $ ../images/printer (4).png?�6*   6R   �� 5#   
   $ ../images/printer (5).png?�6*   6R   �� 5$   
   $ ../images/printer (6).png?�6*   6R   �� 5%   
   $ ../images/printer.png?�6&   6J   �� 5&   
   $ ../images/Printerr.png?�6'   6L   �� 5'   
   $ ../images/profile.png?�6&   6J   �� 5(   
   $ ../images/reply.png?�6$   6F   �� 5)   
   $ ../images/return.png?�6%   6H   �� 5*   
   $  ../images/settings (1).png?�6+   6T   �� 5+   
   $ ../images/settings.png?�6'   6L   �� 5,   
   $! ../images/shopping-cart.png?�60   6Z   �� 5-   
   $ ../images/synchronize.png?�6.   6V   �� 5.   
   $ ../images/users.png?�6$   6F   �� 5/   
   $ ../images/visible (1).png?�6*   6R   �� 50   
   $ ../images/visible (2).png?�6*   6R   �� 51   
   $ ../images/visible (3).png?�6*   6R   �� 52   
   $ ../images/visible.png?�6&   6J   �� 55   
   " ��69   .R�56      �  57        58      CommonStates��. 59        
Normal��6&     5:      	MouseOver��. 5;      �� .��5<   "   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6?   $	 border��6�   .g�5=   &     $
 0��6:   $ 	#FF474747��6F   5>   #   5?      5@        5A      Pressed��6&     5B      Disabled��6&   5C      .+�5E      �� $ border��6   $��0q�6)   ���	#FF333333._�5F      �� $��Center=�6'   $��Center=�6D   5G      5H      5I      5J      .��5K      �  � RowDefinitions 5L   
   �� 5M      $
��Auto �6   �� 5N       5P   
     5Q      -   5        VisualStateGroup��   Transitions 5R      %  System.Windows.VisualTransition  5S         GeneratedDuration$ 0D�6'   	   To$ VisualState��6=      
Storyboard. 5T      �� .��5U      T� $ (UIElement.Visibility)�6<   $	 DD��6o   ..�5V   "   i�  R� KeyTime$ 0��69     System.Windows.Visibility   Visible R� Value# Z 6E   i� 5W   "   $ 0:0:0.1��69      Hidden# Z 6K   5X      5Y      5Z        5[      $ 0D�6'   $ VisualState1��6=   . 5\      �� .��5]      T� $ (UIElement.Visibility)�6<   $	 DD��6o   ..�5^   "   i� $ 0��69   # Z 6E   i� 5_   "   $ 0:0:0.1��69   # Z 6K   5`      5a      5b      . 5d        -   5        VisualState��. 5e      �� .��5f      T� $ (UIElement.Visibility)�68   $	 DD��6k   ..�5g      i� $ 0��65   # Z 6A   5h      5i      5j        5k      -   5        VisualState1��5k      5l      .+�5n   
   �� ���	#FF817F7F$��1q�6)   $��0.042,13.166,2.75,2.834q�6=   $��2��6^   5q      %  DevExpress.Xpf.Grid.GridControl  5r   
   -   5          Name$ DD��5r      $��115.5,1.083,2.771,5.5q�6'   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6F   #   EnableSmartColumnsGeneration .    AllowColumnMRUFilterList .     IsFilterEnabled .     AllowMRUFilterList .     SelectionMode$
 Cell=�6�   $��1��6�   $y�Hidden=�6�      Columns 5s      $	  DevExpress.Xpf.Grid.GridColumn	  5t      -   5        $
  DevExpress.Xpf.Grid.BaseColumn 
 Name$
 iddd��5t   "   $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ id��6.     
  Visible  .  !   Binding! 6=   �� *ID+6T   	  5v      -   5        $ c1��5v   !   $*��$..\fonts\PFDinTextArabic-Regular.ttf)�6+   $ رقم الفاتورة��6g   " 
  Width$" 90��6�   ! 6�   �� *NUMF+6�   	  5w      -   5        $ c2��5w   "   $ اسم المنتج��6,   ! 6C   �� *NAME+	  5x      -	   5        $ c3��5x   !   $ سعر البيع��6+   ! 6A   �� *PRICE+	  5y      -
   5        $ c4��5y   !   $ سعر التكلفة��6+   ! 6C   �� *	PRICE_A+	  5z      -   5        $ c5��5z   !   $ الباركود��6+   ! 6@   �� *	BARCODE+	  5{      -   5        $ c6��5{   !   $ 
اليوم��6+   $" 80��6U   ! 6=   �� *DOW+6U   	  5|      -   5        $ c7��5|   !   $ تاريخ البيع��6+   $	" 130��6[   #   	SortOrder$# 
Descending=�6g   $   	SortIndex$$ 0��6~   ! 6C   �� *DAT+6~   %   View% 5�      #  DevExpress.Xpf.Grid.TableView  5�      &   AllowPerPixelScrolling& . &   DevExpress.Xpf.Grid.DataViewBase'   ShowTotalSummary' . (   	AutoWidth( . )   AllowEditing) .  &   DevExpress.Xpf.Grid.GridViewBase*   ShowGroupPanel* .  6|   5�        5�   
   -   5        $	 DDa��5�      $��115.5,1.083,2.771,5.5q�6(   $
 None=�6G    .  .   .   .  $
 Cell=�6�   $��1��6�    5�      	  5�      $ رقم الفاتورة��6"   $" 90��6T   ! 6;   �� *NUMF+6T   	  5�      $ اسم المنتج��6"   ! 69   �� *NAME+	  5�      $ سعر البيع��6"   ! 68   �� *PRICE+	  5�      $ سعر التكلفة��6"   ! 6:   �� *	PRICE_A+	  5�      $ الباركود��6"   ! 67   �� *	BARCODE+	  5�      $ 
اليوم��6"   $" 80��6L   ! 64   �� *DOW+6L   	  5�      $ تاريخ البيع��6"   $	" 130��6R   $# 
Descending=�6^   $$ 0��6u   ! 6:   �� *DAT+6u   % 5�        5�      & . ' . ( . ) .  * .  6|   5�        5�   
   -   5        $	 DDR��5�      $��115.5,1.083,2.771,5.5q�6(   $
 None=�6G    .  .   .   .  $
 Cell=�6�   $��1��6�    5�      	  5�      $ رمز المنتج��6!   $
" auto��6O   + 	  AllowGrouping]
 YDevExpress.Data.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 
 /DevExpress.Utils.Design.DefaultBooleanConverter$+ False 6\   , 
  AllowMoving$, False 6r   - 
  AllowResizing$- False 6�   .   AllowSorting$. False 6�   / 
  Fixed$
/ Left=�6�   0 
  VisibleIndex$0 0��6�   ! 68   �� *ID+6�   	  5�      $ اسم العميل��6!   $
" auto��6Q   $+ False 6^   $, False 6t   $- False 6�   $. False 6�   $
/ Left=�6�   $0 1��6�   ! 68   �� *NAME+6�   	  5�      $&  تاريخ اضافة الصنف��6!   $
" auto��6Z   $+ False 6g   $, False 6}   $- False 6�   $. False 6�   $
/ Left=�6�   $0 2��6�   1   UnboundType8 
 2DevExpress.Utils.Design.UnboundColumnTypeConverter$1 Object 6�   ! 6?   �� *datrec+6�   	  5�      $$ موعد تسليم الصنف��6!   $
" auto��6V   $+ False 6c   $, False 6y   $- False 6�   $. False 6�   $
/ Left=�6�   $0 3��6�   ! 6>   �� *DAT+6�   	  5�      $ نوع المشكلة��6!   $
" auto��6U   $+ False 6b   $, False 6x   $- False 6�   $. False 6�   $
/ Left=�6�   $0 4��6�   ! 69   �� *	conprou+6�   	  5�      $ تكلفة الصيانة��6!   $
" auto��6U   $+ False 6b   $, False 6x   $- False 6�   $. False 6�   $
/ Left=�6�   $0 5��6�   ! 6;   �� *PRICE+6�   	  5�      $" رقم هاتف العميل��6!   $
" auto��6[   $+ False 6h   $, False 6~   $- False 6�   $. False 6�   $
/ Left=�6�   $0 6��6�   ! 6=   �� *	discounts+6�   	  5�      $ نوع المنتج��6!   $
" auto��6U   $+ False 6b   $, False 6x   $- False 6�   $. False 6�   $
/ Left=�6�   $0 7��6�   ! 68   �� *
typeprou+6�   	  5�      $  ��6!   $" 20��6L   $+ False 6W   $, False 6m   $- False 6�   $. False 6�   $
/ Left=�6�   $0 8��6�   ! 60   �� *isdone+2   EditSettings2 5�      7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings  5�      63   5�      % 5�        5�      & . ( . ) .  * .  ' . 6{   5�      �� 5�   
   -   5        3 ��Name$3 listBox��5�      $
��Left=�6#   $��0.036,1.333,0,6.096q�6>   $��114.464��6[   ���	#FF817F7F$��1,1,1,0q�6�   $��1��6�   .@�5�      �� -   5        4 �� 
IsSelected4 . $��قسم الفواتير��5�   ,   .  (System.Windows.Interactivity.Interaction5   Triggers5 5�      /  )System.Windows.Interactivity.EventTrigger  5�      6   	EventName$6 Selected��6%   .  (System.Windows.Interactivity.TriggerBase7   Actions.7 5�      = 	 7Microsoft.Expression.Interactivity.Core.GoToStateAction  8   	StateName$8 VisualState1��6-   5�      5�      �� 5�      -   5        $��Repair��5�   0   $��قسم الصيانة��6   5�      �� 5�      -   5        $��ListII��5�   1   $��قسم المبيعات��6   5�      5�      %  DevExpress.Xpf.Editors.TextEdit  5�   
   -   5        $��Encode��5�      $y�Visible=�6&   $
��Left=�6f   %  DevExpress.Xpf.Editors.BaseEdit9   NullText$9 ex:/d,/m,/y��6�   $��1.458,0,0,5.855q�6�   $��Bottom=�6�   $��113.062��6�   $��1��6�   ��5�      �� 5�      : �� 
TargetType":  6   ; �� Triggers; 5�      �� 5�      < �� Binding< 6&   �� = �� ElementName$= Repair��> �� Path$> 
IsSelected�? �� Value? True6^   .a�5�      �� @ �� Property@ � y�A �� Value$A Hidden=�6;   6L   5�      5�      5�        5   
   -   5        $��Encode1��5      $y�Hidden=�6&   $
��Left=�6f   $9 ex:/d,/m,/y��6�   $��1.458,0,0,5.855q�6�   $��Bottom=�6�   $��108.187��6�   $��1��6�   ��5     �� 5     ":  6   ; 5     �� 5     < 6&   �� $= Repair��$> 
IsSelected�? True6^   .a�5     �� @ � y�$A Visible=�6;   6M   5     5	     5     �� 5  
   -   5        B ��Name$B ID��5     $
��Left=�6    $
��Wrap=�6l   $	��Top=�6�   $��0.957��6�   $��0.307��6�   $y�Hidden=�6�   ��6;   �� *SelectedItem.ID+$= DD��6�   �� 5  
   -   5        $B id��5     $
��Left=�6!   $
��Wrap=�6<   $	��Top=�6P   $
��2.75��6h   $
��2.96��6u   $y�Hidden=�6�     5  
   -   5        $��SearchingBox��5     $
��Left=�6+   $	��Top=�6F   $&9  بحث برقم الفاتورة��6^   $��112.406��6{   $��1.094,18.145,0,0q�6�   C   MaskType$C RegEx=�6	  D   Mask$D \d{0,9}��6  6L  �� 5  
   -   5        $
B Praq��5     $��Right=�6"   $
��Wrap=�6>   $'��!:مجموع سعر التكلفة��6R   $��Bottom=�6l   $��0,0,5.71,8.336q�6�   ���	#FF101011$
��Bold"�6�   $��1��6�   �� 5  
   -   5        $B 	Praq_Copy��5     $
��Wrap=�6'   $#��:مجموع سعر البيع��6;   $��Bottom=�6S   $��0,0,6.13,23.094q�6n   ���	#FF101011$
��Bold"�6�   $��Right=�6�   $��1��6�   �� 5  
   -   5        $B Resultpri_a��5     $
��Wrap=�6)   $��	SAR  0.00��6=   $��0,0,108.44,8.455q�6N   ���	#FF3399FF$
��Bold"�6   $��9.333(�6�   $��Right=�6�   $��Bottom=�6�   $��1��6�   �� 5  
   -   5        $B 	Resultpri��5     $
��Wrap=�6'   $��	SAR  0.00��6;   $��0,0,99.117,22.454q�6L   ���	#FF3399FF$
��Bold"�6~   $��9.333(�6�   $��Right=�6�   $��Bottom=�6�   $��1��6�   �� 5  
   -   5        E ��Name$E PrivewDoucmentPrinter��5     $��Right=�6k   $��35.168��6�   $��0,15.64,3.754,-0.098q�6�   ��6U   Z� ��6�   Z� .��5     �� $.��(/Pascal;component/images/Print_16x16.png��6   $��Uniform=�6F   5     �� 5  
   -   5        $E Delete��5     $��Right=�6M   $��35.168��6i   $��0,15.552,39.336,-0.125q�6x   ��67   Z� ��6�   Z� .��5     �� $/��)/Pascal;component/images/Delete_32x32.png��6   $��Uniform=�6G   5     5     5     