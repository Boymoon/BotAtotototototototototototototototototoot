   M S B A M L   `   `   `  ����H  DInstagram.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Instagram.AppInstagram.App  5   	   3clr-namespace:Instagram.App.UIInstagram.App.UI  5   W      Instagram.App.Mention   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   'localclr-namespace:Instagram.App  5   	   j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6R   :d2http://schemas.microsoft.com/expression/blend/2008  6�   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6�   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 6  )UIclr-namespace:Instagram.App.UI  	 6W  $	��500��5	   
   $	��600��6     � 
ResizeMode$  NoResize=�6#    � WindowStartupLocation$ CenterScreen=�69    � WindowStyle$ 
ToolWindow=�6�   "  DevExpress.Xpf.Core.DXWindow   BorderEffect$
 None=�6�      
IsAeroMode .  ��6^   ��  �� ElementName$ btnwhiteTemp��.��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��40 �6   �� 5      .+�5   
   %  DevExpress.Xpf.Grid.GridControl  $
��Auto��6   $��	0,10,0,20q�6(   ) 	 #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�6�   	   SelectedItem	 6;   �� *ModelMention+
   ItemsSource
 6a   �� *
UserInfo+   View 5      #  DevExpress.Xpf.Grid.TableView  5         	AutoWidth .    ShowBandsPanel .  & 	  DevExpress.Xpf.Grid.DataViewBase!   ShowSearchPanelCloseButton .     ShowSearchPanelMode$ Never=�6m   &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  6�      Columns 5      $  DevExpress.Xpf.Grid.GridColumn  5      $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ اسم الحساب��6!      Binding 68   �� *
Username+  5      $ عنوان الحساب��6!    6:   �� *Uid+5      � 5   
   $��1��6   .+�5      �� .+�5       �� $��	3,100,3,0q�6      BtnWhite#���   6,    � Cursor$
 Hand��6R   $��>>��6`   �� 5!      $��3,10,3,0q�6   #���   6+   $��>>��6Q    J� RenderTransformOrigin$ 0.5,0.5&�6^   $
 Hand��6~   z�5"      V� 5#      .~�5$      �� �� 5%      �� 5&       �� Angle$	 180Q�6.   T� 5'      5(      5*      5,      5-        5.   
   $
��Auto��6   $��	0,10,0,20q�6(   $��2��6;   $	 Row=�6�   	 6K   �� *ModelMention+
 6q   �� *
UserInfo+ 5/        50       .  .  $ Never=�6U    .  6q    52        53      $ اسم الحساب��6!    68   �� *
Username+  54      $ عنوان الحساب��6!    6:   �� *Uid+56      � 57   
   $��0,0,0,2q�6   $��2��6    $��1��60    58      �� 59      �� 5:      .+�5<      �� $	��100��6   $
 Hand��6$   $��15,0,8.333,1q�62   $��1��6I     BtnWhiteWithIcon#���  6Y   $��param��6�   $��حفظ��6�   
 J� Uid$ bookmark��6�   ��6�   �� *mmodelMention.SaveCommand+6�   �� 5=      -   5        $��btnwhiteTemp��5=   G   $��0��6   $
 Hand��6%   $��
30,0,-10,0q�63   #���   6\   $��param��6�   $��الغاء الامر��6�   $ Close��6�   ��6�   �� *mmodelMention.SaveCommand+6�   5>      5@      5A      