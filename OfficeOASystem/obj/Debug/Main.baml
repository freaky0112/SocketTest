   M S B A M L   `   `   `  ����  OfficeOASystem    OfficeOASystem.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  OfficeOASystem��5      $	��539��6   $	��664��6&    � Triggers 5      :� 5       :� RoutedEvent$ FrameworkElement.Loaded��6   .��5	      � .+�5
   
   � $��10,10,10,10q�6   $��Right=�6$   .+�5      � $
��Left=�6   $��
10,10,0,10q�6/   $��85��6C   .+�5      �� $
��Left=�6   $
��Auto��63   $��Stretch=�6A   $
��Auto��6]   $��0,0,0,0q�6j    �� View 5      �� 5      .P�5      �� $��编号��6!    �� DisplayMemberBinding 6.   �� *ID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   	   $��地块名称��6    6'   �� *ID+$ TwoWay=�$ PropertyChanged=�5      .@�5      �� $��ListViewItem��6   $��0q�64   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgdDLMC��5      $��100,100,10,10q�6)      AutoGenerateColumns .  $��Right=�6]   $��16(�6y   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        DLMC��,  &System.Windows.Controls.DataGridColumn
   Header$
 地类统计��5   4      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6�      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name+$ TwoWay=�$ PropertyChanged=�6�     5      -   5        Area��$
 面积��5   4   $ 2* 6�    6@   �� *Area+$ TwoWay=�$ PropertyChanged=�6�     5      -   5        Lv��$
 等级��5   5   $ * 6�    6A   �� *Level+$ TwoWay=�$ PropertyChanged=�6�   5      � 5      $��90��6   $��100,10,10,0q�6   $	��Top=�64   .+�5      � $��30��6   $	��Top=�6    $��0q�68   .+�5      �� $��地块名称��6   $
��Left=�6%   $	��100��6@   $
��Bold"�6L   $��Center=�6^   $��Center=�6�   �� 5       $��	100,0,0,0q�6    �� TextWrapping$
 Wrap=�61   $��Center=�6E   $��Center=�6g   5!      � 5"      $��30��6   $��0,30,0,0q�6    $	��Top=�62   .+�5#      ]� ��. $��0q�6/    J� RenderTransformOrigin$	 5,5&�6:   $��4��6V   $��4��6f   .+�5$      �� $��乡（镇）��6    $
��Left=�6/   $
��auto��6J   $	��100��6X   $
��Bold"�6d   $��Center=�6v   $��Center=�6�   �� 5%      -   5         ��Name$ cbxXZXZQ��5%   .   $��80��6#   $��Center=�6@   $��Center=�6d    �� Text 6�   �� *XZXZQ+$ TwoWay=�$ PropertyChanged=�6�   �� 5&      $	��村��6    $
��auto��6,   $	��100��6:   $
��Bold"�6F   $��Center=�6X   $��Center=�6z   $��Right=�6�   �� 5'      -   5        $ cbxCXZQ��5'   .   $��80��6#   $��Center=�6?   $��Center=�6c    6�   �� *CXZQ+$ TwoWay=�$ PropertyChanged=��� 5(      $��权属性质��6    $
��auto��6/   $	��100��6=   $
��Bold"�6I   $��Center=�6[   $��Center=�6}   $��Right=�6�   �� 5)      -   5        $ cbxQSXZ��5)   #   $��Center=�64   $��Center=�6X    6z   �� *	LandOwner+$ TwoWay=�$ PropertyChanged=�5*      5+      � 5,      $��30��6   $��0,60,0,0q�6    $	��Top=�62   5-      5.      50      51      