   M S B A M L   `   `   `  ���� 
  Pascal#    Ar_Project.Design.SeinProduct   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006     � Title$   ��$	��350��$	��518�����	#FF333333 � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � WindowStyle$ 
ToolWindow=���Z� .���  � ColumnDefinitions �� $	��70* ��� $
��100* ��� $	��90* ��� $
��115* ��� $	��25* ��� $
��112* �.+��� -    ��Name$
 name��$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$��-18,15.825,5,0q� �� TextAlignment$ Right=�$��4��$��1���� -    ��Name$ 	btnsearch��$��بحث��$
��Left=�$��3,16.188,0,0q�$	��Top=�$��63��$��5��$��22.772��	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   
BlurRadius$
 1Q�   ShadowDepth$ 3Q�%  DevExpress.Xpf.Grid.GridControl  -     Name$ GridData��)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration . $��2,85,2,2q�$��6��   Columns $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ اسم المنتج��   Binding �� *name+  $ سعر المنتج�� �� *price+  $$ تاريخ بيع المنتج�� �� *Date+   View #  DevExpress.Xpf.Grid.TableView     AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .    AllowEditing .     	AutoWidth . 	� -    	�Name$
 year��$��السنة الحالية��$	��Top=�$��5.09,48,1,0q�
�������$��1��	� -   $ mounth��$��الشهر الحالي��$	��Top=�$��7,48,-10.91,0q�
�������$��2��	� -   $	 day��$��اليوم الحالي��$	��Top=�$��22,48,-0.91,0q�
�������$��3��