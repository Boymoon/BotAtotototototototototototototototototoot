   M S B A M L   `   `   `  ���� 
  Pascal    Ar_Project.Design.func   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   $	��611��$	��418�����	#FF333333  � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $	��39* ��� $	��64* � � RowDefinitions �� $	��142 ��� $��26 ��� $	��107 ��� $��30 ��� $��19 ��� $	��229 ��� $��3 ��� $
��22.5 ��� $	��3.5 �.+��� -    ��Name$ S2�����	#FF515151$��1q�$��5��$��2��$��0,0,0,10q�$y�Hidden=�%  DevExpress.Xpf.Grid.GridControl  -     Name$ DD��$��5,5,4,13q�)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration .    AllowColumnMRUFilterList .  	   IsFilterEnabled	 .  
   AllowMRUFilterList
 .     SelectionMode$
 Cell=�$��5��$��2��$y�Hidden=�   Columns $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ اسم المنتج��$  DevExpress.Xpf.Grid.BaseColumn   VisibleIndex$ 0��   Binding �� *NAME+  $ سعر البيع��$ 1�� �� *PRICE+  $ سعر التكلفة��$ 2�� �� *	PRICE_A+  $ رقم الباركود��$ 4�� �� *	BARCODE+  $ كمية المنتج��$ 3�� �� *
QUANTITY+  $ 
الخصم��$ 5�� �� *Dis+  $ الاجمالي��$ 6�� �� *	Price_F+   View #  DevExpress.Xpf.Grid.TableView     AllowPerPixelScrolling .  &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .    AllowEditing .     	AutoWidth . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  �� -    ��Name$
 name��$��22�� �� TextWrapping$
 Wrap=�$	��Top=�$��
60,40,42,0q� �� TextAlignment$ Right=�$��2���� -    ��Name$ 	textBlock��$��Right=�$
��Wrap=�$��:اسم المنتج��$	��Top=����	#FFEAEAEA �� TextAlignment$ Right=�$��	0,19,43,0q�$��64��$��16��$��1��$y�Hidden=��� -   $	 bar��$��23��$
 Wrap=�$��Bottom=�$��
60,0,42,26q�$ Right=�$��2���� -   $ textBlock_Copy��$��Right=�$
��Wrap=�$��:رقم الباركود��$��Bottom=����	#FFEAEAEA$ Right=�$��	0,0,43,54q�$��84��$��16��$��1��$y�Hidden=��� -   $ pri_a��$
 Wrap=�$��60,4,42,106q�$ Right=�$��1��$��2��$��2��$y�Hidden=��� -   $	 pri��$
 Wrap=�$��
0,33,42,51q�$ Right=�$��2��$��1��$y�Hidden=��� -	   $ TX_Copy��$��Right=�$
��Wrap=�$��:سعر التكلفة�����	#FFEAEAEA$ Right=�$��	0,0,43,25q�$��84��$��Bottom=�$��16��$��1��$��2��$y�Hidden=��� -
   $ TX��$��Right=�$
��Wrap=�$��:سعر البيع��$	��Top=����	#FFEAEAEA$ Right=�$��	0,12,43,0q�$��64��$��2��$��16��$��1��$y�Hidden=��� -   $	 qua��$��23��$
 Wrap=�$��Bottom=�$��
60,0,42,27q�$ Right=�$��2��$��2��$��2��$y�Hidden=��� -   $ textBlock_Copy2��$��Right=�$
��Wrap=�$��:كمية المنتج��$��Bottom=����	#FFEAEAEA$ Right=�$��	0,0,43,23q�$��64��$��2��$��16��$��1��$y�Hidden=��� -    ��Name$ btn_add��$��اضافة ��$��135,15,92,4q�$��3��$��2��$��2��$y�Hidden=� J� Effect 3	  -System.Windows.Media.Effects.DropShadowEffect	   	  ShadowDepth$ 2Q��� -   $ 	name_Copy��$��22��$
 Wrap=�$	��Top=�$��
60,40,42,0q�$ Right=�$��2��$y�Hidden=����� *SelectedItem.NAME+ �� ElementName$ DD���� -   $ bar_Copy��$��23��$
 Wrap=�$��Bottom=�$��
60,0,42,26q�$ Right=�$��2��$y�Hidden=����� *SelectedItem.BARCODE+$ DD��%
  DevExpress.Xpf.Editors.TextEdit
  -    
 Name$ 
pri_a_Copy��)  #DevExpress.Xpf.Editors.TextEditBase    TextWrapping$
  Wrap=�$��60,4,42,106q�$��Right=�$��1��$y�Hidden=�$��2��$��2��!   Text! �� *SelectedItem.PRICE_A+$ DD��
  -   $ pri_Copy��$
  Wrap=�$��Right=�$��
0,33,42,51q�$y�Hidden=�$��2��$��1��$��1��! �� *SelectedItem.PRICE+$ DD���� -   $ qua_Copy��$��23��$
 Wrap=�$��Bottom=�$��
60,0,42,27q�$ Right=�$��2��$��2��$��2��$y�Hidden=����� *SelectedItem.QUANTITY+$ DD���� -   $ btn_add_Copy��$��
تعديل��$��135,7,92,12q�$��3��$��2��$��2��$y�Hidden=� 	  $ 2Q��� -   $ MA_ID��$
��Left=�$��30��$��	0,-60,0,0q�$
��Wrap=�$	��Top=�$	��120������ *SelectedItem.ID+$ DD���� �� �� �� -   $ maName��$��22��$
 Wrap=�$	��Top=�$��
60,40,42,0q�$ Right=�$y�Hidden=�$��2���� -   $ textBlock_Copy3��$��Right=�$
��Wrap=�$��:اسم المورد��$	��Top=����	#FFEAEAEA$ Right=�$��	0,19,43,0q�$��64��$��16��$y�Hidden=�$��1���� -   $ maBar��$��23��$
 Wrap=�$��Bottom=�$��
60,0,42,26q�$ Right=�$y�Hidden=�$��2���� -   $ textBlock_Copy4��$��Right=�$
��Wrap=�$��:رقم الباركود��$��Bottom=����	#FFEAEAEA$ Right=�$��	0,0,43,54q�$��84��$y�Hidden=�$��16��$��1��  -   $	 DDD��$��	5,58,4,26q�$
 None=� .  .  	 .  
 .  $
 Cell=�$��2��$��4��$y�Hidden=�$��2��   $ اسم المورد�� �� *NAME+  $" رقم هاتف المورد�� �� *NUM+    .  .  .   .  .  �� -   $ btnMA��$��اضافة ��$��135,136,92,2q�$y�Hidden=�$��2��$��2�� 	  $ 2Q��� -   $ B�����	#FF515151$��1q�$��	3,52,2,25q�$��2��$��4��$y�Hidden=�$��2���� -   $ 
MA_ID_Copy��$��30��$��4,-60,132,0q�$
��Wrap=�$	��Top=�$��1������ *SelectedItem.ID+$	 DDD���� �� �� �� -   $ L��$��Right=�$
��Wrap=�$��:رقم الهاتف��$��Bottom=����	#FFEAEAEA$ Right=�$��	0,0,43,54q�$��84��$��16��$y�Hidden=�$��1���� -   $ maName_Copy��$��22��$
 Wrap=�$	��Top=�$��
60,40,42,0q�$ Right=�$y�Hidden=�$��2������ *SelectedItem.NAME+$	 DDD���� -   $ 
maBar_Copy��$��23��$
 Wrap=�$��Bottom=�$��
60,0,42,26q�$ Right=�$y�Hidden=�$��2������ *SelectedItem.NUM+$	 DDD���� -    $ btnMAEd��$��
تعديل��$��135,136,92,2q�$y�Hidden=�$��2��$��2�� 	  $ 2Q�
  -!   $ Dis_add��$��23��$��	60,33,0,0q�$��2��$	��Top=�$��96��%  DevExpress.Xpf.Editors.BaseEdit"   NullText$" 0%��$y�Hidden=��� -"   $ Tx_Add��$��Right=�$
��Wrap=�$��:الخصم��$	��Top=����	#FFEAEAEA$ Right=�$��0,12,0,0q�$��64��$��2��$��16��$y�Hidden=�
  -#   $ Dis_edit��$
��Left=�$��23��$��	60,33,0,0q�$��2��$	��Top=�$��96��$" 0%��$y�Visible=�! �� *SelectedItem.Dis+$ DD���� -$   $ Tx_Edit��$��Right=�$
��Wrap=�$��:الخصم��$	��Top=����	#FFEAEAEA$ Right=�$��0,12,0,0q�$��64��$��2��$��16��