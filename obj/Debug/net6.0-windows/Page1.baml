   M S B A M L   `   `   `  ����J  FLab4_TDH_CS3260, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab4Lab4  5          
Lab4.Page1   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Lab4     5        N� 
Background
  ����� N� Title$ Page1��5
      .��5      � .+�5   
   �� -   5         ��Name$ 
addSavings��5      $��Savings Account��6%   $
��Left=�6?   $��	82,24,0,0q�6Z   $	��Top=�6m   6�   �� 5   
   -   5        $ addChecking��5      $��Checking Account��6&   $
��Left=�6A   $��
345,24,0,0q�6\   $	��Top=�6p    J� RenderTransformOrigin$ 0.051,-2.471&�6�   �� 5   
   -   5        $ addCD��5      $��
CD Account��6    $
��Left=�65   $��
627,24,0,0q�6P   $	��Top=�6d   6|   �� 5   
   -   5         ��Name$ accName��5      $
��Left=�6#   $��	67,91,0,0q�6>    �� TextWrapping$
 Wrap=�6Q   $��Account Name��6e   $	��Top=�6y   $	��120��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 
accAddress��5      $
��Left=�6&   $��
259,91,0,0q�6A   $
 Wrap=�6U   $��Address��6i   $	��Top=�6x   $	��120��6�   $ -1.062,0.706&�6�   $y�Hidden=�6�   �� 5   
   -   5        $ 
accBalance��5      $
��Left=�6&   $��
425,91,0,0q�6A   $
 Wrap=�6U   $��Balance��6i   $	��Top=�6x   $	��120��6�   $ 0.485,-1.554&�6�   $y�Hidden=�6�   �� 5   
   -   5        $ accType��5      $
��Left=�6#   $��
600,91,0,0q�6>   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�    �� 
IsReadOnly$
 True��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 	submitBtn��5      $��Create Account��6$   $��Center=�6=   $��	0,195,0,0q�6Z   $	��Top=�6m   $	��110��6�   $��30��6�   $y�Hidden=�6�   �� 5   
   -	   5         ��Name$ accNameError��5      $��Invalid Name��6&   $
��Left=�6=   $��
67,132,0,0q�6X   $	��Top=�6l   $	��120��6�   ���	#FFFF0B0B$y�Hidden=�6�   �� 5   
   -
   5        $ accAddressError��5      $��Invalid Address��6)   $
��Left=�6C   $��259,132,0,0q�6^   $	��Top=�6s   $	��120��6�   ���	#FFFF0B0B$y�Hidden=�6�   �� 5   
   -   5        $ accBalanceError��5      $��Invalid Balance��6)   $
��Left=�6C   $��425,132,0,0q�6^   $	��Top=�6s   $	��120��6�   ���	#FFFF0B0B$y�Hidden=�6�   �� 5   
   -   5        $��accountInfo��5      $��Center=�6'   $
��Wrap=�6D   $��Account Created!��6X   $	��Top=�6p   $��28��6�   $	��640��6�   $��	0,252,0,0q�6�    �� TextAlignment$ Center=�6�   $y�Hidden=�6�   5      5      