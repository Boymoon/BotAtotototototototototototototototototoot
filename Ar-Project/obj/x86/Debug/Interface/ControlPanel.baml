   M S B A M L   `   `   `  ����A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Ar_Project.InterfaceAr_Project.Interface  5   �  'clr-namespace:Ar_Project
Ar_Project  5   	       Ar_Project.ControlPanel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   HCustom;http://schemas.devexpress.com/winfx/2008/xaml/core/internal  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  6T   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6�   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   6�   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6  h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 6\  2	Interface"clr-namespace:Ar_Project.Interface 	 6�  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6�  $localclr-namespace:Ar_Project  5   	     � Title$  ControlPanel��5	   	   $	��600��6   $	��800��6+    � 
ResizeMode$ CanMinimize=�68    � 	Resources 5
       	  coins �� 	UriSource  1463935404_plus  
dollar-bag  eye (1)  eye (2)  eye (3)  eye 1 -font-awesome_4-7-0_print_1024_256_ecf0f1_none 0 ,font-awesome_4-7-0_print_252_143_ecf0f1_none .	 *font-awesome_4-7-0_print_47_28_ecf0f1_none %
 !horizontal-line-remove-button (2) ! horizontal-line-remove-button  	interface  
line-chart 
 locked  	money-bag  oval (1)  oval (2)  oval (3)  oval  pencil-edit-button  plus-symbol  printer (1)  printer (2)  printer (4)  printer (5)  printer (6)  printer  Printerr  profile 	 reply 
 return   settings (1) ! settings " shopping-cart.png # synchronize.png 	$ users % visible (1) & visible (2) ' visible (3) ( visible ) ButtonControlTemplate1 �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value ��Name��%�  &	        &	 2     &	 n     &	 �     &	 �     &	     &	 A    &	 q    &	 �    &		 $    &	
 {    &	 �    &	     &	 I    &	 �    &	 �    &	 �    &	     &	 S    &	 �    &	 �    &	 �    &	 0    &	 h    &	 �    &	 �    &	     &	 H    &	 |    &	 �    &	 �    &	     &	  J    &	! �    &	" �    &	# �    &	$ *    &	% \    &	& �    &	' �    &	( 	    &	) 8	    �� 5   
   $ ../images/coins.png?�6$   6F   �� 5   
   $# ../images/1463935404_plus.png?�6.   6Z   �� 5   
   $ ../images/dollar-bag.png?�6)   6P   �� 5   
   $ ../images/eye (1).png?�6&   6J   �� 5   
   $ ../images/eye (2).png?�6&   6J   �� 5   
   $ ../images/eye (3).png?�6&   6J   �� 5   
   $ ../images/eye.png?�6"   6B   �� 5   
   $A ;../images/font-awesome_4-7-0_print_1024_256_ecf0f1_none.png?�6L   6�   �� 5   
   $@ :../images/font-awesome_4-7-0_print_252_143_ecf0f1_none.png?�6K   6�   �� 5   
   $> 8../images/font-awesome_4-7-0_print_47_28_ecf0f1_none.png?�6I   6�   �� 5   
   $5 /../images/horizontal-line-remove-button (2).png?�6@   6~   �� 5   
   $1 +../images/horizontal-line-remove-button.png?�6<   6v   �� 5   
   $ ../images/interface.png?�6(   6N   �� 5   
   $ ../images/line-chart.png?�6)   6P   �� 5   
   $ ../images/locked.png?�6%   6H   �� 5   
   $ ../images/money-bag.png?�6(   6N   �� 5   
   $ ../images/oval (1).png?�6'   6L   �� 5   
   $ ../images/oval (2).png?�6'   6L   �� 5   
   $ ../images/oval (3).png?�6'   6L   �� 5   
   $ ../images/oval.png?�6#   6D   �� 5   
   $&  ../images/pencil-edit-button.png?�61   6`   �� 5    
   $ ../images/plus-symbol.png?�6*   6R   �� 5!   
   $ ../images/printer (1).png?�6*   6R   �� 5"   
   $ ../images/printer (2).png?�6*   6R   �� 5#   
   $ ../images/printer (4).png?�6*   6R   �� 5$   
   $ ../images/printer (5).png?�6*   6R   �� 5%   
   $ ../images/printer (6).png?�6*   6R   �� 5&   
   $ ../images/printer.png?�6&   6J   �� 5'   
   $ ../images/Printerr.png?�6'   6L   �� 5(   
   $ ../images/profile.png?�6&   6J   �� 5)   
   $ ../images/reply.png?�6$   6F   �� 5*   
   $ ../images/return.png?�6%   6H   �� 5+   
   $  ../images/settings (1).png?�6+   6T   �� 5,   
   $ ../images/settings.png?�6'   6L   �� 5-   
   $! ../images/shopping-cart.png?�60   6Z   �� 5.   
   $ ../images/synchronize.png?�6.   6V   �� 5/   
   $ ../images/users.png?�6$   6F   �� 50   
   $ ../images/visible (1).png?�6*   6R   �� 51   
   $ ../images/visible (2).png?�6*   6R   �� 52   
   $ ../images/visible (3).png?�6*   6R   �� 53   
   $ ../images/visible.png?�6&   6J   �� 56   
   " ��69   .R�57      �  58        59      CommonStates��. 5:        
Normal��6&     5;      	MouseOver��. 5<      �� .��5=   "   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6?   $	 border��6�   .g�5>   &     $
 0��6:   $ 	#FF474747��6F   5?   #   5@      5A        5B      Pressed��6&     5C      Disabled��6&   5D      .+�5F      �� $ border��6   $��0q�6)   ���	#FF333333._�5G      �� $��Center=�6'   $��Center=�6D   5H      5I      5J      5K      .��5L      �  5M   
     5N      -   5        VisualStateGroup��5N      .+�5P   
   %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ DT��5P      $��0.083,95,0.083,0.25q�6'   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6D   #   EnableSmartColumnsGeneration .    AllowColumnMRUFilterList .     IsFilterEnabled .     AllowMRUFilterList .     SelectionMode$
 Cell=�6�      Columns 5Q      $  DevExpress.Xpf.Grid.GridColumn  5R      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ id��6!   $	  DevExpress.Xpf.Grid.BaseColumn 	  Visible .     Binding 6@   �� *ID+  5T      $ اسم الحساب��6!    68   �� *NAME+  5U      $$ كلمة مرور الحساب��6!    6>   �� *PASS+  5V      $ الصلاحية��6!    66   �� *STATE+   View 5Z      #
  DevExpress.Xpf.Grid.TableView
  5[       
  AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .  
  	AutoWidth .    AllowEditing .  6g   5]      �� 5^   
   
�������$��1q�6$   $��9.25,51,2.875,3q�68   $y�Hidden=�6Q   �� 5`   
   $��1q�6   $��Right=�6%   $��38.496��6A   $��0,56.114,0.069,0q�6Q   $	��Top=�6k   $��87.333��6�   ���	#FFE8E8E8._�5b      � .+�5c      �� -   5         ��Name$ 
btndelete1��5c      $��45.911,2.14,2.484,0q�6.   $��31.998��6K   $	��Top=�6[   .��5d      �� $/��)/Pascal;component/images/Delete_32x32.png��6   5g      �� 5h      -   5        $ btnedit��5h      $��Right=�6+   $��36.938��6G   $��0,2.306,43.922,0q�6W   $��31.998��6q   $	��Top=�6�   .  (System.Windows.Interactivity.Interaction   Triggers 5j      /  )System.Windows.Interactivity.EventTrigger  5k         	EventName$ Click��6)   .  (System.Windows.Interactivity.TriggerBase    Actions.  5l      = 	 7Microsoft.Expression.Interactivity.Core.GoToStateAction  !   	StateName$! VisualState��61   5m      .��5p      �� $-��'/Pascal;component/images/Edit_32x32.png��6   5t      5u      5v      � 5w   
   -   5        " �Name$" XX��5w      $��250.5,262.107,228,107.393q�6   # J� RenderTransformOrigin$# 0.5,0.5&�6>   $y�Hidden=�6^   z�5x      V� 5y      .~�5z      �� �� 5{      �� 5|      T� 5}      5~      $ � RowDefinitions$ 5�      �� 5�      $	��26* �6    �� 5�      $	��16* �6    �� 5�      $	��22* �6    �� 5�      $	��18* �6    �� 5�      $	��23* �6    �� 5�      $	��18* �6    �� 5�      $	��24* �6    �� 5�      $	��53* �6    .+�5�      �� -   5        $ border��5�      ���	#FFF07B10$��1q�6=   $��1.5,0,-1.833,0.501q�6Q   ���	#FF333333$��8��6�   �� 5�      -   5        % ��Name$
% name��5�      & �� TextWrapping$
& Wrap=�6V   $��26,-0.872,37.5,-0.935q�6j   $��2��6�   ' �� TextAlignment$' Right=�6�   ��6$   �� *SelectedItem.NAME+( �� ElementName$( DT��6�   �� 5�      -   5        $
% pass��5�      $
& Wrap=�6V   $ ��26.835,0.777,36.665,-0.827q�6j   $��4��6�   $' Right=�6�   ��6$   �� *SelectedItem.PASS+$( DT��6�   �� 5�      -	   5        $% state��5�      $
& Wrap=�6X   $��26,0.288,37.5,1.178q�6l   $��6��6�   $' Right=�6�   ��6%   �� *SelectedItem.STATE+$( DT��6�   �� 5�      -
   5        $ button��5�      $��
تعديل��6%   $��Right=�65   $��0,9.334,37.333,18.668q�6Q   $��84��6p   $��7��6{   ) J� Effect) 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�      *   ShadowDepth$* 2Q�6'   5�      �� 5�      -   5        + ��Name$+ 	textBlock��5�      $��Right=�6+   $
��Wrap=�6G   ���	#FFD8D8D8$��65.667��6r   $��0,-2.913,36.979,2.299q�6�   $��1��6�   �� 6�   , �� FlowDirection$, RightToLeft=�6�   $�اسم الحساب:��6�   6�   �� 5�      -   5        $+ textBlock_Copy��5�      $��Right=�60   $
��Wrap=�6L   ���	#FFD8D8D8$��59.667��6w   $��0,0.402,36.354,-0.557q�6�   $��:كلمة المرور��6�   $��3��6�   �� 5�      -   5        $+ textBlock_Copy1��5�      $��Right=�61   $
��Wrap=�6M   ���	#FFD8D8D8$��46.292��6x   $��0,1.208,36.527,0q�6�   $��:الصلاحية��6�   $��5��6�   5�      �� 5�   
   -   5        $ button2��5�      $��×��6"   $��0,263.583,227.816,276.084q�6.   #��� ) 6Q   $��18.667(�6�   $��Right=�6�   $��31.668��6�   $y�Hidden=�6�    5�        5�      $ Click��6!   .  5�        $! VisualState1��6)   5�      5�      �� 5�   
   -   5        $+ id��5�      $
��Left=�6P   $
��Wrap=�6k   $	��Top=�6   
���   �$y�Hidden=�6�   ��6    �� *SelectedItem.ID+$( DT��6�   5�      5�      