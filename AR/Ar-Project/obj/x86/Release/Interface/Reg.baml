   M S B A M L   `   `   `  ���� A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ar_Project
Ar_Project      Ar_Project.Reg   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  $localclr-namespace:Ar_Project  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  $��346.5��$	��354��  � WindowStyle$  ThreeDBorderWindow=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $	��85* ��� $��7* ��� $��23 ��� $��8* ��� $��23 ��� $��9* ��� $��2* ��� $��23 ��� $	��13* ��� $
��125* � � ColumnDefinitions �� $	��30* ��� $	��11* ��� $
��275* ��� $	��33* �.+��� -    ��Name$
 name�� �� TextWrapping$
 Wrap=�$��0.167,6.451,0.333,-1.069q�$��1��$��2��$y�Hidden=�$��2��$��2���� -   $
 pass��$
 Wrap=�$��0.333,6.736,0.333,-0.499q�$��1��$��4��$y�Hidden=�$��2��$��2���� -    ��Name$ cm��$��2��$��Right=�$��0.031,2.825,11.292,-6.137q�$��7�� �� SelectedIndex$ 0��$y�Hidden=�.@��� $��عضو��$��Right=��� $��
مسؤول��$��Right=��� -   	 ��Name$	 	textBlock��$��-9.5,-3.515,0,-5.998q�$
��Wrap=�$��	Username:��$��2��$
��Left=�$��83.847�����	#FFAAAAAA$��1��$y�Hidden=��� -   
 ��Name$
 button��$��
Regstier
��$��2��$��72.5,24.981,83,0q�$��9��$	��Top=�$��22.96�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 2Q�%  DevExpress.Xpf.Editors.TextEdit  -     Name$ 
name_style��$��2��$��1.5,-0.337,11,-0.347q�$��2��$��Right=�%  DevExpress.Xpf.Editors.BaseEdit   NullText$ اسم المستخدم��,  &DevExpress.Xpf.Editors.PasswordBoxEdit  -     Name$ 
pass_style��$��2��$��1.5,0.658,11.333,-1.34q�$��Right=�$��4��$ كلمة المرور��)  #DevExpress.Xpf.Editors.ComboBoxEdit  -     Name$ cm_style��$��1.5,-0.001,11.375,-0.668q�$��Right=�$ الصلاحية��$��2��$��7��+  %DevExpress.Xpf.Editors.LookUpEditBase   ImmediatePopup .    EditValuePostMode$ 	Immediate=�'  !DevExpress.Xpf.Editors.ButtonEdit   IsTextEditable$ FalseX�*  $DevExpress.Xpf.Editors.PopupBaseEdit   IsPopupOpen .    StyleSettings 2	  ,DevExpress.Xpf.Editors.ComboBoxStyleSettings	     Items. -
  'DevExpress.Xpf.Editors.ComboBoxEditItem
  $��
مسؤول��
  $��عضو��