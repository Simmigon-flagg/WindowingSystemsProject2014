   M S B A M L   `   `   `  ����  PROJECT     WpfApplication1.addPatient   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ��5   7   Z� .��5      � $	��387��6"   $	��374��6.   ��6   Z� .+�5	   
   �� -   5        $��txtFname��5	   1   $��23��6   $��	10,36,0,0q�6   $	��Top=�6A   
�������$
��Left=�6l   $	��178��6�   �� 5
   
   -   5        $��txtLname��5
   1   $��23��6   $��	0,36,16,0q�6   $	��Top=�6A   
�������$��Right=�6l   $	��175��6�   �� 5   
   -   5        $��
txtAddress��5   2   $��23��6   $��
11,77,16,0q�6   $	��Top=�6D   
�������6\   �� 5   
   -   5        $��txtDOB��5   M   $��23��6   $
��Left=�6   $��
12,117,0,0q�69   $	��Top=�6[   $	��112��6s   
�������6   �� 5   
   -   5        $��txtSSN��5   N   $��23��6   $
��Left=�6   $��131,117,0,0q�69   $	��Top=�6\   $	��111��6t   
���   �
�������6�   �� 5   
   -   5        $��txtPhone��5   N   $��23��6   $
��Left=�6   $��249,117,0,0q�69   $	��Top=�6^   $	��122��6v   
�������6�   �� 5   
   -   5        $��cbGender��5   `     �� 
IsEditable  .  �� 
IsReadOnly .  �� Text$ 
--Select--��6   $��23��6%   $
��Left=�61   $��
13,157,0,0q�6L   $	��Top=�6p   $	��110��6�   .@�5      �� $��M��6   �� 5      $��F��6   5      �� 5   
   -   5        $��	cbVeteran��5   [     .  . $ 
--Select--��6   $��23��6   $
��Left=�6+   $��132,158,0,0q�6F   $	��Top=�6l   $	��111��6�   .@�5      �� $	��Yes��6   �� 5      $��No��6   5      �� 5   
   -	   5        $��cbHealthConcern��5   J     . $ --Select Health Concern--��5      $��23��5      $��Right=�6   $��0,199,145,0q�65   $	��Top=�6a   $	��229��6y   .@�5      �� $��Asthma��6   �� 5       $��Allergy��6   �� 5!      $��Ligaments and Bones��6   �� 5"      $��Diabetes��6   �� 5#      $��Hypertension��6   �� 5$      $��Blood transfusion��6   �� 5%      $��Trauma Injury��6   �� 5&      $	��Flu��6   �� 5'      $��Antibiotitics��6   5(      �� 5)   
   -
   5        $��label1��5)   ^   $��
First Name��6   $��28��6%   $
��Left=�61   $��5,16,0,0q�6L   $	��Top=�6l   
���   �6�   �� 5*   
   -   5        $��label2��5*   `   $��	Last Name��6   $��28��6$   $��Right=�60   $��
0,16,130,0q�6L   $	��Top=�6n   �� 5+   
   -   5        $��label3��5+   [   $��Address��6   $��28��6"   $
��Left=�6.   $��7,58,0,0q�6I   $	��Top=�6i   �� 5,   
   -   5        $��label4��5,   a   $��Date of Birth��6   $��28��6(   $
��Left=�64   $��8,98,0,0q�6O   $	��Top=�6o   �� 5-   
   -   5        $��label5��5-   f   $��Social Security ��6   $��28��6+   $
��Left=�67   $��
126,97,0,0q�6R   $	��Top=�6t   �� 5.   
   -   5        $��label6��5.   [   $��Phone��6   $��28��6    $
��Left=�6,   $��
244,98,0,0q�6G   $	��Top=�6i   �� 5/   
   -   5        $��label7��5/   [   $��Gender��6   $��28��6!   $
��Left=�6-   $��	8,137,0,0q�6H   $	��Top=�6i   �� 50   
   -   5        $��label8��50   ^   $��Veteran��6   $��28��6"   $
��Left=�6.   $��128,138,0,0q�6I   $	��Top=�6l   $��59��6�   �� 51   
   -   5        $��label9��51   `   $��Add Patient��6   $��45��6&   $
��Left=�62   $��	6,-13,0,0q�6M   $	��Top=�6n   $��22(�6�   $	��160��6�   �� 52   
   -   5        $��scrollViewer1��52   R   $��88��6   $
��Left=�6#   $��
13,225,0,0q�6>   $	��Top=�6g   $	��355��6   .��53      �� -   5        $��txtDescr��53       �� TextWrapping$
 Wrap=�6'    �� AcceptsReturn .  �� 
AcceptsTab . 6P   54      �� 55   
   -   5        $��label10��55   d   $��Health Concern:��6   $��28��6*   $
��Left=�66   $��	9,178,0,0q�6Q   $	��Top=�6s   �� 56   
   -   5        $��	checkBox1��56   j   $��Insurance Covered��6   $��16��6/   $
��Left=�6;   $��
16,319,0,0q�6V   $	��Top=�6{    �� ContentStringFormat$ Covered��6�   57      58      