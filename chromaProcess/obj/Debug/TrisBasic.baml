   M S B A M L   `   `   `  ����H  DchromaProcess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:chromaProcesschromaProcess  5   	       chromaProcess.TrisBasic   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:chromaProcess     5   	   -   5          � Title$  	TrisBasic��5   	   $	��300��6   $	��350��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��120 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��
(Xr,Yr,Zr)��6   $��Right=�6%   $��0,20,5,0q�6A   $	��Top=�6S   �� 5   
   $��
(Xg,Yg,Zg)��6   $��Right=�6%   $��0,20,5,0q�6A   $��1��6S   $	��Top=�6`   �� 5   
   $��
(Xb,Yb,Zb)��6   $��Right=�6%   $��0,20,5,0q�6A   $��2��6S   $	��Top=�6`   �� 5   
   $��目标色(Xb,Yb,Zb)��6   $��Right=�6(   $��0,20,5,0q�6D   $��3��6V   $	��Top=�6c   �� 5   
   -   5         ��Name$ 
btnConfirm��5      $��确定��6%   $��Right=�62   $��0,0,5,5q�6N   $��4��6_   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ 	btnCancel��5      $��取消��6$   $��1��61   $
��Left=�6A   $��4��6]   $��75��6j   $��	20,0,50,5q�6�   $	��Top=�6�   �� 5   
   -   5        $��BasicRed��5      $��1��6"   $
��Left=�62   $��23��6M   $��0,25,0,0q�6Y    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   �� 5   
   -   5        $��
BasicGreen��5      $��1��6$   $
��Left=�64   $��23��6O   $��0,25,0,0q�6[   $��1��6m   $
 Wrap=�6z   $	��Top=�6�   �� 5   
   -   5        $��	BasicBlue��5      $��1��6#   $
��Left=�63   $��23��6N   $��0,25,0,0q�6Z   $��2��6l   $ NoWrap=�6y   $	��Top=�6�   �� 5   
   -   5        $��TargetColor��5      $��1��6%   $
��Left=�65   $��23��6P   $��0,25,0,0q�6\   $��3��6n   $ NoWrap=�6{   $	��Top=�6�   $	��100��6�   5      5       