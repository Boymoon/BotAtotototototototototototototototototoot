   M S B A M L   `   `   `  ����
  Pascal#    Ar_Project.Design.SeinProduct   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      <d2http://schemas.microsoft.com/expression/blend/2008   6D   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6�     � Title$   ��5      $	��350��6   $	��518��6   ���	#FF333333 � WindowStartupLocation$ CenterScreen=�6?    � 
ResizeMode$ CanMinimize=�6d    � WindowStyle$ 
ToolWindow=�6}   ��6�   Z� .��5      �  � ColumnDefinitions 5   
   �� 5      $	��70* �6   �� 5      $
��100* �6   �� 5      $	��90* �6   �� 5      $
��115* �6   �� 5      $	��25* �6   �� 5      $
��112* �6   .+�5   
   �� -   5         ��Name$
 name��5      $��23��6     �� TextWrapping$
 Wrap=�6,   $	��Top=�6@   $��-18,15.825,5,0q�6X    �� TextAlignment$ Right=�6p   $��4��6�   $��1��6�   �� 5   
   -   5         ��Name$ 	btnsearch��5      $��بحث��6$   $
��Left=�62   $��3,16.188,0,0q�6M   $	��Top=�6c   $��63��6{   $��5��6�   $��22.772��6�   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   
BlurRadius$
 1Q�6#      ShadowDepth$ 3Q�62   5      %  DevExpress.Xpf.Grid.GridControl  5   
   -   5          Name$ GridData��5      )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6,   #   EnableSmartColumnsGeneration . $��2,85,2,2q�6k   $��6��6}      Columns 5      $  DevExpress.Xpf.Grid.GridColumn  5      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ اسم المنتج��6!      Binding 68   �� *name+  5      $ سعر المنتج��6!    68   �� *price+  5      $$ تاريخ بيع المنتج��6!    6>   �� *Date+   View 5!      #  DevExpress.Xpf.Grid.TableView  5"         AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .    AllowEditing .     	AutoWidth . 6k   5$      	� 5%   
   -   5         	�Name$
 year��5%      $��السنة الحالية��6$   $	��Top=�6<   $��5.09,48,1,0q�6T   
�������$��1��6|   	� 5&   
   -   5        $ mounth��5&      $��الشهر الحالي��6&   $	��Top=�6=   $��7,48,-10.91,0q�6U   
�������$��2��6   	� 5'   
   -   5        $	 day��5'      $��اليوم الحالي��6#   $	��Top=�6:   $��22,48,-0.91,0q�6R   
�������$��3��6|   5(      5)      