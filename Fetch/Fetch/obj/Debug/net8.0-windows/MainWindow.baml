   M S B A M L   `   `   `  ����@  <Fetch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FetchFetch  5   	       Fetch.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Fetch     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��
Enter URL:��6   $��0��6%   $��Center=�62   �� 5   
   -   5        $��
UrlTextBox��5      $��0��6$   $��80,0,0,0q�61   $��Center=�6C   �� 5   
   -   5        $��FetchDataButton��5      $��
Fetch Data��6(   $��1��6=   $��0,10,0,0q�6J   $	��100��6\   $
��Left=�6h   6�   �� 5   
   -   5        $��ClearButton��5      $��Clear��6$   $��1��64   $��
110,10,0,0q�6A   $	��100��6U   $
��Left=�6a   6|   �� 5   
   -   5        $��CloseButton��5      $��Close��6$   $��1��64   $��
220,10,0,0q�6A   $	��100��6U   $
��Left=�6a   6|   �� 5   
   -   5        $��ResultTextBox��5      $��2��6'   $��	0,10,0,10q�64   " �� VerticalScrollBarVisibility$
 Auto=�6G   $ �� HorizontalScrollBarVisibility$
 Auto=�6j    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn$
 True��6�    �� 
IsReadOnly$
 True��6�   5      5      