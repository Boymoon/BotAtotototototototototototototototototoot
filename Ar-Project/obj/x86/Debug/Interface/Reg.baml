   M S B A M L   `   `   `  ����A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project  5   	       Ar_Project.Reg   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   $localclr-namespace:Ar_Project  5   	   a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   6H   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6�   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6�   h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 6%  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6j  $��346.5��5      $	��354��6     � WindowStyle$  ThreeDBorderWindow=�6     � 
ResizeMode$ NoResize=�6A    � WindowStartupLocation$ CenterScreen=�6W   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��85* �6   �� 5      $��7* �6   �� 5      $��23 �6   �� 5      $��8* �6   �� 5      $��23 �6   �� 5      $��9* �6   �� 5      $��2* �6   �� 5      $��23 �6   �� 5      $	��13* �6   �� 5      $
��125* �6    � ColumnDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��11* �6   �� 5      $
��275* �6   �� 5      $	��33* �6   .+�5   
   �� -   5         ��Name$
 name��5       �� TextWrapping$
 Wrap=�6    $��0.167,6.451,0.333,-1.069q�64   $��1��6x   $��2��6�   $y�Hidden=�6�   $��2��6�   $��2��6�   �� 5   
   -   5        $
 pass��5      $
 Wrap=�6    $��0.333,6.736,0.333,-0.499q�64   $��1��6x   $��4��6�   $y�Hidden=�6�   $��2��6�   $��2��6�   �� 5   
   -   5         ��Name$ cm��5      $��2��6   $��Right=�6/   $��0.031,2.825,11.292,-6.137q�6S   $��7��6v    �� SelectedIndex$ 0��6�   $y�Hidden=�6�   .@�5      �� $��عضو��6   $��Right=�6)   �� 5       $��
مسؤول��6   $��Right=�6+   5!      �� 5"   
   -   5        	 ��Name$	 	textBlock��5"      $��-9.5,-3.515,0,-5.998q�6'   $
��Wrap=�6E   $��	Username:��6Y   $��2��6j   $
��Left=�6z   $��83.847��6�   ���	#FFAAAAAA$��1��6�   $y�Hidden=�6�   �� 5#   
   -   5        
 ��Name$
 button��5#      $��
Regstier
��6!   $��2��6>   $��72.5,24.981,83,0q�6N   $��9��6h   $	��Top=�6u   $��22.96��6�    J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         ShadowDepth$ 2Q�6#   5'      %  DevExpress.Xpf.Editors.TextEdit  5(   
   -   5          Name$ 
name_style��5(      $��2��6+   $��1.5,-0.337,11,-0.347q�6;   $��2��6Y   $��Right=�6f   %  DevExpress.Xpf.Editors.BaseEdit   NullText$ اسم المستخدم��6�   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5)   
   -   5          Name$ 
pass_style��5)      $��2��62   $��1.5,0.658,11.333,-1.34q�6B   $��Right=�6b   $��4��6�   $ كلمة المرور��6�   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5*   
   -   5          Name$ cm_style��5*      $��1.5,-0.001,11.375,-0.668q�6-   $��Right=�6P   $ الصلاحية��6s   $��2��6�   $��7��6�   +  %DevExpress.Xpf.Editors.LookUpEditBase   ImmediatePopup .    EditValuePostMode$ 	Immediate=�6�   '  !DevExpress.Xpf.Editors.ButtonEdit   IsTextEditable$ FalseX�6	  *  $DevExpress.Xpf.Editors.PopupBaseEdit   IsPopupOpen .    StyleSettings 5+      2	  ,DevExpress.Xpf.Editors.ComboBoxStyleSettings	  5,         Items. 5.      -
  'DevExpress.Xpf.Editors.ComboBoxEditItem
  $��
مسؤول��6#   
  5/      $��عضو��6#   50      52      53      