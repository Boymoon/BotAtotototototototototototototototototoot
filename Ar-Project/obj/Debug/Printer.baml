   M S B A M L   `   `   `  ����E  AAr-Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project  5   	       Ar_Project.Printer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Ar_Project     5   	   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   -   5          � Title$  Printer��5	   	   $��505.5��6   $	��420��6(   ���	#FF333333 � 
ResizeMode$ CanMinimize=�6K   .��5
      � .+�5   
   �� -   5         ��Name$ Print��5      $/��)pack://application:,,,/fonts/#FontAwesome)�6    $��Right=�6X   $��0,213.862,11.492,0q�6t   $��36.167��6�   $��32��6�   $	��Top=�6�   .��5      �� $��printer (5).png��6   5      �� 5   
   -   5         ��Name$ Barcode��5      $��23��6#    �� TextWrapping$
 Wrap=�6/   $	��Top=�6C   $��19.5,65.998,31,0q�6[   6u   �� 5   
   -   5        $
 Name��5      $��23��6    $
 Wrap=�6,   $	��Top=�6@   $��19.5,115.523,31,0q�6X   {�.  6s   �� 5   
   -   5        $ price��5      $
 Wrap=�6!   $��19.5,166.547,31,0q�65   $��23��6P   $	��Top=�6\   {�.  6t   �� 5   
   -   5         ��Name$ 	textBlock��5      $��Right=�6'   $��23.334��6C   $��0,42.998,32.666,0q�6S   $
��Wrap=�6n   $	��Top=�6�   $��60.667��6�   ���	#FFC7C7C7$��:رقم الباركود
��6�   �� 5   
   -   5        $ textBlock_Copy��5      $��Right=�6,   $��19.084��6H   $��0,96.335,30.666,0q�6X   $
��Wrap=�6s   $	��Top=�6�   $��57.417��6�   ���	#FFC7C7C7$��:اسم المنتج��6�   �� 5   
   -   5        $ textBlock_Copy1��5      $��Right=�6-   $��0,147.167,31.166,0q�6I   $
��Wrap=�6e   $��52.167��6y   ���	#FFC7C7C7$��:ثمن البيع��6�   $��19.584��6�   $	��Top=�6�   �� 5   
   ���	#FF515151$��1q�6)   $��5,248.683,5,4.667q�6=   �� 5   
   ���	#FF515151$��1q�6)   $��Right=�6=   $��0,209.497,5,0q�6Y   $��50��6p   $��40��6{   $	��Top=�6�   %  DevExpress.Xpf.Grid.GridControl  5   
   -	   5          Name$ DD��5      $��8.167,260.122,8,10.036q�6&   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6F   #   EnableSmartColumnsGeneration . 	   AllowColumnMRUFilterList	 .  
   IsFilterEnabled
 .     AllowMRUFilterList .     SelectionMode$
 Cell=�6�      Columns 5      $  DevExpress.Xpf.Grid.GridColumn  5      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ اسم المنتج��6!      Binding 68   �� *Name+  5      $ ثمن المنتج��6!    68   �� *Price+  5       $ رقم الباركود��6!    6:   �� *	Barcode+   View 5"      #  DevExpress.Xpf.Grid.TableView  5#         AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .    AllowEditing .     	AutoWidth .  6k   5%      5'      5(      