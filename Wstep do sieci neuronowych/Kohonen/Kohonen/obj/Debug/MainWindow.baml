   M S B A M L   `   `   `  ����B  >Kohonen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:KohonenKohonen  5   	       Kohonen.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Kohonen     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��400��6)    � 
ResizeMode$ NoResize=�65   .��5	      � .+�5
   
   �� -   5        $��	mojCanvas��5
      ��5      �� 5       �� Color$ White��6"    �� Opacity$ 0Q�60   .+�5      �� -   5         ��Name$ buttonStart��5      $��Start��6*   $
��Left=�6:   $	��Top=�6U   $��75��6m    �� Left$	 307��6�   
 �� Top$ 10��6�   � 5      -   5        $��kohonenPolyline��5      
����  �$��5��6<   �� 5      ��6   �� *Points+ �� ElementName$ kohonenPolyline����5      �� 5      .R�5      �� 5      ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 �@��Left
 �� Value
 68   �� *X+�� 5      	 �@��Top
 67   �� *Y+5      ��5      �� 5      .R�5      �� 
����  �$��5��6-    �� StrokeStartLineCap$ Round=�5        �� StrokeEndLineCap$ Round=�6.   5!      5#      5%      5&      5'      