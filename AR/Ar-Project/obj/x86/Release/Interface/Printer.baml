   M S B A M L   `   `   `  ���� A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project      Ar_Project.Printer   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  $localclr-namespace:Ar_Project  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -   $��505.5��$	��420��  � 
ResizeMode$  CanMinimize=�.��� .+��� -    ��Name$ Print��$/��)pack://application:,,,/fonts/#FontAwesome)�$��Right=�$��0,213.237,4.571,0q�$��36.167��$��32��$	��Top=�.���� $.��(/Pascal;component/images/Print_16x16.png���� -    ��Name$ Barcode��$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$��19.5,65.998,31,0q��� -   $
 Name��$��23��$
 Wrap=�$	��Top=�$��19.5,115.523,31,0q�{�.  �� -   $ price��$
 Wrap=�$��19.5,166.547,31,0q�$��23��$	��Top=�{�.  �� -    ��Name$ 	textBlock��$��Right=�$��23.334��$��0,42.998,32.666,0q�$
��Wrap=�$	��Top=�$��60.667�����	#FF272525$��:رقم الباركود
���� -   $ textBlock_Copy��$��Right=�$��19.084��$��0,96.335,30.666,0q�$
��Wrap=�$	��Top=�$��57.417�����	#FF272525$��:اسم المنتج���� -   $ textBlock_Copy1��$��Right=�$��0,147.167,31.166,0q�$
��Wrap=�$��52.167�����	#FF272525$��:سعر البيع��$��19.584��$	��Top=��� 
�������$��1q�$ ��0.062,248.683,-0.021,4.667q��� 
�������$��1q�$��Right=�$��0,209.497,0.011,0q�$��46.667��$��40��$	��Top=�%  DevExpress.Xpf.Grid.GridControl  -	     Name$ DD��$��1.068,260.122,6,10.036q�)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration .    AllowColumnMRUFilterList .  	   IsFilterEnabled	 .  
   AllowMRUFilterList
 .     SelectionMode$
 Cell=�   Columns $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ اسم المنتج��   Binding �� *Name+  $ سعر البيع�� �� *Price+  $ رقم الباركود�� �� *	Barcode+   View #  DevExpress.Xpf.Grid.TableView     AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .    AllowEditing .     	AutoWidth .  �� -
   $ 
textBlock1��$��0,226.835,46.328,0q�$
��Wrap=����	#FF070827$��Right=�$��64.651��$
��18.5��$	��Top=���  �� FlowDirection$ RightToLeft=�$�الاجمالي:���� -   $ Pricce��$��0,227.832,114.232,0q�$
��Wrap=����	#FF101011$
��Bold"�$��Right=�$	��Top=��� $ RightToLeft=�$�0��