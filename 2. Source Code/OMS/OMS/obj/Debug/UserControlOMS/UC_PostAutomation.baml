   M S B A M L   `   `   `  ����  OMS(    "OMS.UserControlOMS.UC_SchedulePost   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         PostAutomationUCVM  � DataContext#  [  5        MaterialDesignBody#���  5	      $��Regular"�5
      $��15(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+   CommandParameter 6F   ��  �� ElementName$ OmsMainWindow��5      .��5      � .+�5   
   � 	 � ColumnDefinitions	 5      �� 5      �� 5      $��2* �6#   .+�5      �� $��0��6   $��Automation Post��5         MaterialDesignCardGroupBox#���  5!      $��5,5,0,5q�5"      ��5$      �� 5%      .R�5&      �� 
 �� Orientation$
 
Horizontal=�6%   .+�5'      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ ReorderHorizontal=�66   $��32��5(   6   $��32��5)   6   $��Center=�5*   6   �� 5+      $��8,0,0,0q�6(   $��Center=�5,   (    % !MaterialDesignSubheadingTextBlock#��[ 5-   (   ��5.   (   �� 5/      50      .��54      �� $
 Vertical=�6   .+�55      �� -   5         ��Name$ TextBoxCaption��56      $	��Top=�55      $��10q�57       �� TextWrapping$
 Wrap=�58      $��Stretch=�59      $	��280��5:      $	��200��5;      " �� VerticalScrollBarVisibility$
 Auto=�5<       �� AcceptsReturn . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Content *��5?      .	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  TextBoxViewMargin$ 1 5 1 5q�5@         FloatingScale$	 0.7Q�5A       % !MaterialDesignFloatingHintTextBox#��[ 5B      ��5>      �� *Description+5B      �� 5C      -   5         ��Name$ ComboBoxDestination��5E      $��50��5C      $��10q�5D      $ Destination��5F       �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 5H      .@�5I      �� $
��Zalo��6'   �� 5J       �� 
IsSelected . $��Facebook��5K   '   5L      �� 5M      -   5        $ ComboBoxProduct��5R       . $��50��5N      $
��auto��5O      $��10q�5P      $ 	Products*��5Q       �� SelectedValuePath$
 Name��5T       �� DisplayMemberPath$
 Name��5U      #��[ 5X      ��5S      �� *ListProduct+ �� SelectedItem 5V      �� *!ComboboxProductListSelectedItem+ �� SelectedValue 5W      �� *" ComboboxProductListSelectedValue+5X      �� 5Y      $
 
Horizontal=�6!   $��10,15,10,10q�5Z   !   .+�5[      (
  "System.Windows.Controls.DatePicker
  -   5         
 Name$ DateTimePickerDate��5`   %   $��40��5[   %   $	��200��5\   %   $��0,0,5,0q�5]   %    
  SelectedDateFormat$ Short=�5^   %   $
��Left=�5_   %   $ 
Pick Date*��5b   %    ( $MaterialDesignFloatingHintDatePicker#��[ 5c   %    
  FirstDayOfWeek$ Monday=�5d   %    
  SelectedDate 5a   %   �� *DateTimePickerDate+5d   %   )  #MaterialDesignThemes.Wpf.TimePicker  5e      -   5          Name$ DateTimePickerTime��5g   4      	Is24Hours . $
��Left=�5f   4       SelectedTimeFormat$  Short=�5h   4   $ 
Pick Time*��5j   4   $��40��5k   4   $	��200��5l   4   $��5,0,0,0q�5m   4   !   SelectedTime! 5i   4   �� *DateTimePickerTime+5m   4   5n      5p      5r      �� 5v      $��1��6   $
��List��5w      #���  5x      $��5,5,5,5q�5y      ��5{      �� 5|      .R�5}      �� $
 
Horizontal=�6%   .+�5~        $ ReorderHorizontal=�66   $��32��5   6   $��32��5�   6   $��Center=�5�   6   �� 5�      $��8,0,0,0q�6(   $��Center=�5�   (   #��[ 5�   (   ��5�   (   �� 5�      5�      .��5�      � " � RowDefinitions" 5�      �� 5�      �� 5�      $��4* �6(   �� 5�      .+�5�      � $��0��6   $��5q�6(   .+�5�      �� $��1��6%   $
 
Horizontal=�5�   %   $
��Left=�5�   %   .+�5�      �� $ Page Id*��6&   $��40��5�   &   $	��220��5�   &   $��5q�5�   &   #��[ 5�   &   ��5�   &   �� *
FbPageId+5�   &   �� 5�      $ 	UserName*��6&   $��40��5�   &   $	��220��5�   &   $��5q�5�   &   #��[ 5�   &   ��5�   &   �� *
FbUsername+5�   &   G� 5�      -   5        # G�Name$# PasswordBoxFbPassword��5�   *   $��40��5�   *   $	��220��5�   *   $��5q�5�   &   $ Password��5�   *    5�   "     5�   &   $ PasswordChanged��65   . 5�   *      6@   �� *PasswordChangedCommand+ 6k   �� $ PasswordBoxFbPassword��5�   '   5�      �� 5�       "	 MaterialDesignRaisedDarkButton#��[	 6%   $	��150��5�   %   $��30,5,5,5q�5�   %   $��	Get Token��5�   %   ��5�   %   �� *GetTokenCommand+��5�   %   �� $ PasswordBoxFbPassword��5�      5�      �� 5�      $��1q�6   ���#3F51B5$	��Top=�5�      $��1��5�      ._�5�      �� -   5        $ ��Name$$ ListSchedulePost��5�   #   $	��Top=�5�   #   $	��530��5�   #    5�   #   �� *ListSchedulePostSelectedItem+��5�   #   �� *ListSchedulePost+% �� View% 5�      �� 5�   "   .P�5�   &   �� $��ID bài đăng��5�   5   & �� DisplayMemberBinding& 5�   5   �� *Id+5�   5   �� 5�   &   $��Nội dung bài đăng��5�   5   & 5�   5   �� *	Message+5�   5   �� 5�   &   $��Thời gian hiển thị��5�   5   & 5�   5   �� *CreatedTime+5�   5   5�   #   5�      5�      �� 5�      $��2��6!   $
 
Horizontal=�5�   !   $��Center=�5�   !   {�5�   !   �� *ShowActionButton+.+�5�      �� -   5        ' ��Name$' 
ButtonLoad��5�   !   #��[	 5�   !   $	��150��5�   !   $��5,5,5,5q�5�   !   $
��Load��5�   !   ��5�   !   �� *LoadCommand+5�   !   �� 5�      -	   5        $' ButtonCreate��5�   !   #��[	 5�   !   $	��150��5�   !   $��5,5,5,5q�5�   !   $��Create��5�   !   ��5�   !   �� *CreateCommand+5�   !   �� 5�      #��[	 6!   $��5,5,5,5q�5�   !   $��Create with all product��5�   !   ��5�   !   �� *CreateWithAllProductsCommand+5�   !   �� 5�      #��[	 6!   $	��150��5�   !   $��5,5,5,5q�5�   !   $��Delete��5�   !   ��5�   !   �� *DeleteCommand+5�      5�      5�      5�      5�      5�      