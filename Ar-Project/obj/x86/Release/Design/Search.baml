   M S B A M L   `   `   `  ���� A  =Pascal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Ar_Project.DesignAr_Project.Design      Ar_Project.Design.Search   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:Ar_Project.Design     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  $	��250��$��415.001�����	#FF333333  � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=����	#FFFF8800$	��0.6q� � 	Resources    
OnChecked1  
OnChecked2 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%�   &	        &	      �� �� .��U� $ (UIElement.Opacity)�$
 path��.\�  $ 0��$ 0Q�U� $ (UIElement.Opacity)�$ 
textBlock2��.\�  $ 0��$ 0Q�.��� '  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  -   VisualStateGroup��	   Transitions	 %  System.Windows.VisualTransition  
   GeneratedDuration$
 0D�	   To$ VisualState��   
Storyboard. �� .��W�  g� Duration$ 0:0:0.3D�	 W� To$ 1X�$ (UIElement.Opacity)�$ 
textBlock2��U� $ (UIElement.Opacity)�$
 path��.\�  $ 0��$ 0Q�  $ 0:0:0.3��$ 1Q�  $ 0:0:0.7��$ 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$
 path��.\�  $ 0��$ 0Q�  $ 0:0:0.3��$
 -175Q�  $ 0:0:0.7��$
 -175Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$
 path��.\�  $ 0��$ 0Q�  $ 0:0:0.3��$ 4Q�  $ 0:0:0.7��$ 4Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 
textBlock2��.\�  $ 0:0:0.3��$
 -175Q�  $ 0:0:0.7��$
 -175Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 
textBlock2��.\�  $ 0:0:0.3��$ 4Q�  $ 0:0:0.7��$ 4Q�T� $ (UIElement.Visibility)�$
 path��..�i�  R� KeyTime$ 0��  System.Windows.Visibility   Visible R� Value# Z i� $ 0:0:0.3��# Z T� $ (UIElement.Visibility)�$ 
textBlock2��..�i� $ 0��# Z i� $ 0:0:0.3��# Z    States.    System.Windows.VisualState  -   VisualState��   
Storyboard. �� .��U� $ (UIElement.Opacity)�$ 
textBlock2��.\�  $ 0��$ 1Q�  $ 0:0:1.51��$ 1Q�  $ 0:0:2.02��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$
 path��.\�  $ 0��$
 -175Q�  $ 0:0:1.51��$
 -175Q�  $ 0:0:2.02��$ 5Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 
textBlock2��.\�  $ 0��$
 -175Q�  $ 0:0:1.51��$
 -175Q�  $ 0:0:2.02��$ 5Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$
 path��.\�  $ 0��$ 4Q�  $ 0:0:1.51��$ 4Q�  $ 0:0:2.02��$ 3Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ 
textBlock2��.\�  $ 0��$ 4Q�  $ 0:0:1.51��$ 4Q�  $ 0:0:2.02��$ 3Q�U� $ (UIElement.Opacity)�$
 path��.\�  $ 0��$ 1Q�  $ 0:0:1.51��$ 1Q�  $ 0:0:2.02��$ 0Q�T� $ (UIElement.Visibility)�$
 path��..�i� $ 0��# Z i� $ 0:0:1.51��# Z i� $ 0:0:2.02��# Z T� $ (UIElement.Visibility)�$ 
textBlock2��..�i� $ 0��# Z i� $ 0:0:1.51��# Z i� $ 0:0:2.02��# Z   -   VisualState1��. �� .��T� $ (UIElement.Visibility)�$
 path��..�i� $ 0��   Hidden# Z T� $ (UIElement.Visibility)�$ 
textBlock2��..�i� $ 0��# Z  � RowDefinitions �� $	��29* ��� $	��14* ��� $
��106* �.+��� -    ��Name$ search��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��281��$��	27,25,0,0q� �� TextAlignment$ Right=�	� -    	�Name$ radioButton��$"��بحث في المشاريع��$
��Left=�$��27,0,0,0q�$��1��$	��Top=�$	��123�����	#FFE9E9E9	� -   $ radioButton_Copy��$"��بحث في المنتجات��$
��Left=�$��	200,0,0,0q�$��1��$	��Top=�$	��108�����	#FFE9E9E9� $��2�� �� $	��17* ��� $	��17* ��� $	��17* ��� $	��17* ��� $	��46* � � ColumnDefinitions �� �� $��78 �.+��� -    ��Name$ SH��$��5��$��1��.+��� -    ��Name$ 	textBlock��$
��Left=�$
��Wrap=�$��:اسم المنتج��$	��Top=�$��64�����	#FFE9E9E9 �� TextAlignment$ Right=�$��40���� -	   $ textBlock_Copy��$
��Left=�$
��Wrap=�$ ��:باركود المنتج��$��4,0,0,0q�$��64�����	#FFE9E9E9$ Right=�$��40���� -
   $ textBlock_Copy1��$
��Left=�$
��Wrap=�$��:ثمن المنتج��$	��Top=�$��64�����	#FFE9E9E9$ Right=�$��40���� -   $ textBlock_Copy2��$
��Left=�$
��Wrap=�$��:كمية المنتج ��$	��Top=�$��68�����	#FFE9E9E9$ Right=�$��40���� -   $ SV��$
��Left=�$	��177��$��5��$	��Top=�$	��336��.+��� -   $
 Name��$
��Left=�$
��Wrap=�$	��Top=�$	��336�����	#FFE9E9E9$ Right=�$��40��$
��Bold"��� -   $	 bar��$
��Left=�$
��Wrap=�$��20,0,0,0q�$	��316�����	#FFE9E9E9$ Right=�$��40��$
��Bold"��� -   $	 pri��$
��Left=�$
��Wrap=�$	��Top=�$	��336�����	#FFE9E9E9$ Right=�$��40��$
��Bold"��� -   $	 qua��$
��Left=�$
��Wrap=�$	��Top=�$	��336�����	#FFE9E9E9$ Right=�$��40��$
��Bold"��� -   $	 SH_��$��5��$��1��.+��� -   $ 
textBlock1��$
��Left=�$
��Wrap=�$��:اسمع المشروع��$	��Top=�$��74.199�����	#FFE9E9E9$ Right=�$��28.199���� -   $ textBlock_Copy3��$
��Left=�$
��Wrap=�$��:ثمن المشروع��$��4,0,0,0q�$��70.199�����	#FFE9E9E9$ Right=�$��28���� -   $ textBlock_Copy4��$
��Left=�$
��Wrap=�$��:حالة المشروع��$	��Top=�$��74.199�����	#FFE9E9E9$ Right=�$��28���� -   $	 SV_��$
��Left=�$	��177��$��5��$	��Top=�$	��336��$��0,0,-0.199,-0.001q�.+��� -   $ Name1��$
��Left=�$
��Wrap=�$	��Top=�$	��330�����	#FFE9E9E9$ Right=�$��30��$
��Bold"��� -   $
 bar1��$
��Left=�$
��Wrap=�$��20,0,0,0q�$	��310�����	#FFE9E9E9$ Right=�$��30��$
��Bold"��� -   $
 pri1��$
��Left=�$
��Wrap=�$	��Top=�$	��330�����	#FFE9E9E9$ Right=�$��30��$
��Bold"��� -    ��Name$ button��$��بحث ��$
��Left=�$��314,25,0,0.091q�$��91�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect      ShadowDepth$  2Q�F� -   ! F�Name$
! path��F���� N ��� N�zF�����zF�����`� .�M�����ڿ����� �	���	#FF3399FF$��0,0,-171.199,7.8q�" �� Stretch$
" Fill=����	#FF383838$��Right=�$��2��$	��165��$��36��$��Bottom=�# J� RenderTransformOrigin$# 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ 
textBlock2��$
��Wrap=�$2��,.لم يتم العثور  على نتيجة��$��0,0,-151.199,12.19q����	#FFE4E4E4$
��Bold"�$ Right=�$��Right=�$��2��$	��130��$��27.185��$��Bottom=�$# 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ A��$
��Left=�$��80��$��-35,0,0,-6.2q�$��2��$
 Wrap=�$��TextBox��$��Bottom=�$��0���� -   $ ��Name$$ AA��$��CheckBox��$
��Left=�$��55��$��-45,0,0,-6.2q�$��2��$��Bottom=�$��15��.  (System.Windows.Interactivity.Interaction%   Triggers% /	  )System.Windows.Interactivity.EventTrigger	  & 	  	EventName$& Checked��.
  (System.Windows.Interactivity.TriggerBase' 
  Actions.' =  7Microsoft.Expression.Interactivity.Core.GoToStateAction  (   	StateName$( VisualState��	  $& 	Unchecked��.'   $( VisualState1���� -   $ button1��$��خروج��$
��Left=�$��29��$��	4,143,0,0q�$	��Top=�$	��103��$��2��   $  2Q�