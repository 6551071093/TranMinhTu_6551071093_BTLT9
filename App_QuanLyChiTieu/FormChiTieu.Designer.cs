namespace App_QuanLyChiTieu
{
    partial class FormChiTieu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grBx_ThongTinKhoanChi = new GroupBox();
            numDn_SoTien = new NumericUpDown();
            lbl_SoTien = new Label();
            txt_GhiChu = new TextBox();
            cbo_LoaiChi = new ComboBox();
            txt_NoiDung = new TextBox();
            dtp_NgayChi = new DateTimePicker();
            lbl_GhiChu = new Label();
            lbl_LoaiChi = new Label();
            lbl_NoiDung = new Label();
            lbl_NgayChi = new Label();
            grBx_TimKiem = new GroupBox();
            btn_Tim = new Button();
            dtp_DenNgay = new DateTimePicker();
            dtp_TuNgay = new DateTimePicker();
            lbl_DenNgay = new Label();
            lbl_TuNgay = new Label();
            cbo_ChonLoaiChi = new ComboBox();
            lbl_NhapLoaiChi = new Label();
            txt_NhapNoiDung = new TextBox();
            lbl_NhapNoiDung = new Label();
            btn_Them = new Button();
            btn_Sua = new Button();
            btn_Xoa = new Button();
            btn_LamMoi = new Button();
            dgv_ChiTieu = new DataGridView();
            lbl_TongChi = new Label();
            grBx_ThongTinKhoanChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDn_SoTien).BeginInit();
            grBx_TimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ChiTieu).BeginInit();
            SuspendLayout();
            // 
            // grBx_ThongTinKhoanChi
            // 
            grBx_ThongTinKhoanChi.Controls.Add(numDn_SoTien);
            grBx_ThongTinKhoanChi.Controls.Add(lbl_SoTien);
            grBx_ThongTinKhoanChi.Controls.Add(txt_GhiChu);
            grBx_ThongTinKhoanChi.Controls.Add(cbo_LoaiChi);
            grBx_ThongTinKhoanChi.Controls.Add(txt_NoiDung);
            grBx_ThongTinKhoanChi.Controls.Add(dtp_NgayChi);
            grBx_ThongTinKhoanChi.Controls.Add(lbl_GhiChu);
            grBx_ThongTinKhoanChi.Controls.Add(lbl_LoaiChi);
            grBx_ThongTinKhoanChi.Controls.Add(lbl_NoiDung);
            grBx_ThongTinKhoanChi.Controls.Add(lbl_NgayChi);
            grBx_ThongTinKhoanChi.Location = new Point(12, 12);
            grBx_ThongTinKhoanChi.Name = "grBx_ThongTinKhoanChi";
            grBx_ThongTinKhoanChi.Size = new Size(720, 231);
            grBx_ThongTinKhoanChi.TabIndex = 0;
            grBx_ThongTinKhoanChi.TabStop = false;
            grBx_ThongTinKhoanChi.Text = "Thông tin khoản chi";
            // 
            // numDn_SoTien
            // 
            numDn_SoTien.Location = new Point(451, 85);
            numDn_SoTien.Name = "numDn_SoTien";
            numDn_SoTien.Size = new Size(263, 27);
            numDn_SoTien.TabIndex = 7;
            // 
            // lbl_SoTien
            // 
            lbl_SoTien.AutoSize = true;
            lbl_SoTien.Location = new Point(376, 87);
            lbl_SoTien.Name = "lbl_SoTien";
            lbl_SoTien.Size = new Size(55, 20);
            lbl_SoTien.TabIndex = 6;
            lbl_SoTien.Text = "Số tiền";
            // 
            // txt_GhiChu
            // 
            txt_GhiChu.Location = new Point(102, 166);
            txt_GhiChu.Multiline = true;
            txt_GhiChu.Name = "txt_GhiChu";
            txt_GhiChu.ScrollBars = ScrollBars.Vertical;
            txt_GhiChu.Size = new Size(612, 52);
            txt_GhiChu.TabIndex = 9;
            // 
            // cbo_LoaiChi
            // 
            cbo_LoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_LoaiChi.FormattingEnabled = true;
            cbo_LoaiChi.Location = new Point(102, 127);
            cbo_LoaiChi.Name = "cbo_LoaiChi";
            cbo_LoaiChi.Size = new Size(250, 28);
            cbo_LoaiChi.TabIndex = 5;
            // 
            // txt_NoiDung
            // 
            txt_NoiDung.Location = new Point(102, 84);
            txt_NoiDung.Name = "txt_NoiDung";
            txt_NoiDung.Size = new Size(250, 27);
            txt_NoiDung.TabIndex = 3;
            // 
            // dtp_NgayChi
            // 
            dtp_NgayChi.CustomFormat = "dd/MM/yyyy";
            dtp_NgayChi.Format = DateTimePickerFormat.Custom;
            dtp_NgayChi.Location = new Point(102, 35);
            dtp_NgayChi.Name = "dtp_NgayChi";
            dtp_NgayChi.Size = new Size(250, 27);
            dtp_NgayChi.TabIndex = 1;
            // 
            // lbl_GhiChu
            // 
            lbl_GhiChu.AutoSize = true;
            lbl_GhiChu.Location = new Point(6, 179);
            lbl_GhiChu.Name = "lbl_GhiChu";
            lbl_GhiChu.Size = new Size(58, 20);
            lbl_GhiChu.TabIndex = 8;
            lbl_GhiChu.Text = "Ghi chú";
            // 
            // lbl_LoaiChi
            // 
            lbl_LoaiChi.AutoSize = true;
            lbl_LoaiChi.Location = new Point(6, 131);
            lbl_LoaiChi.Name = "lbl_LoaiChi";
            lbl_LoaiChi.Size = new Size(60, 20);
            lbl_LoaiChi.TabIndex = 4;
            lbl_LoaiChi.Text = "Loại chi";
            // 
            // lbl_NoiDung
            // 
            lbl_NoiDung.AutoSize = true;
            lbl_NoiDung.Location = new Point(6, 87);
            lbl_NoiDung.Name = "lbl_NoiDung";
            lbl_NoiDung.Size = new Size(71, 20);
            lbl_NoiDung.TabIndex = 2;
            lbl_NoiDung.Text = "Nội dung";
            // 
            // lbl_NgayChi
            // 
            lbl_NgayChi.AutoSize = true;
            lbl_NgayChi.Location = new Point(6, 40);
            lbl_NgayChi.Name = "lbl_NgayChi";
            lbl_NgayChi.Size = new Size(69, 20);
            lbl_NgayChi.TabIndex = 0;
            lbl_NgayChi.Text = "Ngày Chi";
            // 
            // grBx_TimKiem
            // 
            grBx_TimKiem.Controls.Add(btn_Tim);
            grBx_TimKiem.Controls.Add(dtp_DenNgay);
            grBx_TimKiem.Controls.Add(dtp_TuNgay);
            grBx_TimKiem.Controls.Add(lbl_DenNgay);
            grBx_TimKiem.Controls.Add(lbl_TuNgay);
            grBx_TimKiem.Controls.Add(cbo_ChonLoaiChi);
            grBx_TimKiem.Controls.Add(lbl_NhapLoaiChi);
            grBx_TimKiem.Controls.Add(txt_NhapNoiDung);
            grBx_TimKiem.Controls.Add(lbl_NhapNoiDung);
            grBx_TimKiem.Location = new Point(747, 12);
            grBx_TimKiem.Name = "grBx_TimKiem";
            grBx_TimKiem.Size = new Size(466, 231);
            grBx_TimKiem.TabIndex = 1;
            grBx_TimKiem.TabStop = false;
            grBx_TimKiem.Text = "Tìm Kiếm";
            // 
            // btn_Tim
            // 
            btn_Tim.Location = new Point(343, 165);
            btn_Tim.Name = "btn_Tim";
            btn_Tim.Size = new Size(100, 36);
            btn_Tim.TabIndex = 8;
            btn_Tim.Text = "Tìm";
            btn_Tim.UseVisualStyleBackColor = true;
            // 
            // dtp_DenNgay
            // 
            dtp_DenNgay.CustomFormat = "dd/MM/yyyy";
            dtp_DenNgay.Format = DateTimePickerFormat.Custom;
            dtp_DenNgay.Location = new Point(88, 174);
            dtp_DenNgay.Name = "dtp_DenNgay";
            dtp_DenNgay.Size = new Size(235, 27);
            dtp_DenNgay.TabIndex = 7;
            // 
            // dtp_TuNgay
            // 
            dtp_TuNgay.CustomFormat = "dd/MM/yyyy";
            dtp_TuNgay.Format = DateTimePickerFormat.Custom;
            dtp_TuNgay.Location = new Point(88, 135);
            dtp_TuNgay.Name = "dtp_TuNgay";
            dtp_TuNgay.Size = new Size(235, 27);
            dtp_TuNgay.TabIndex = 5;
            // 
            // lbl_DenNgay
            // 
            lbl_DenNgay.AutoSize = true;
            lbl_DenNgay.Location = new Point(6, 179);
            lbl_DenNgay.Name = "lbl_DenNgay";
            lbl_DenNgay.Size = new Size(72, 20);
            lbl_DenNgay.TabIndex = 6;
            lbl_DenNgay.Text = "Đến ngày";
            // 
            // lbl_TuNgay
            // 
            lbl_TuNgay.AutoSize = true;
            lbl_TuNgay.Location = new Point(6, 140);
            lbl_TuNgay.Name = "lbl_TuNgay";
            lbl_TuNgay.Size = new Size(62, 20);
            lbl_TuNgay.TabIndex = 4;
            lbl_TuNgay.Text = "Từ ngày";
            // 
            // cbo_ChonLoaiChi
            // 
            cbo_ChonLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_ChonLoaiChi.FormattingEnabled = true;
            cbo_ChonLoaiChi.Location = new Point(88, 84);
            cbo_ChonLoaiChi.Name = "cbo_ChonLoaiChi";
            cbo_ChonLoaiChi.Size = new Size(355, 28);
            cbo_ChonLoaiChi.TabIndex = 3;
            // 
            // lbl_NhapLoaiChi
            // 
            lbl_NhapLoaiChi.AutoSize = true;
            lbl_NhapLoaiChi.Location = new Point(6, 87);
            lbl_NhapLoaiChi.Name = "lbl_NhapLoaiChi";
            lbl_NhapLoaiChi.Size = new Size(60, 20);
            lbl_NhapLoaiChi.TabIndex = 2;
            lbl_NhapLoaiChi.Text = "Loại chi";
            // 
            // txt_NhapNoiDung
            // 
            txt_NhapNoiDung.Location = new Point(88, 39);
            txt_NhapNoiDung.Name = "txt_NhapNoiDung";
            txt_NhapNoiDung.PlaceholderText = "Nhập nội dung cần tìm...";
            txt_NhapNoiDung.Size = new Size(355, 27);
            txt_NhapNoiDung.TabIndex = 1;
            // 
            // lbl_NhapNoiDung
            // 
            lbl_NhapNoiDung.AutoSize = true;
            lbl_NhapNoiDung.Location = new Point(6, 42);
            lbl_NhapNoiDung.Name = "lbl_NhapNoiDung";
            lbl_NhapNoiDung.Size = new Size(71, 20);
            lbl_NhapNoiDung.TabIndex = 0;
            lbl_NhapNoiDung.Text = "Nội dung";
            // 
            // btn_Them
            // 
            btn_Them.Location = new Point(88, 249);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(96, 36);
            btn_Them.TabIndex = 2;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = true;
            // 
            // btn_Sua
            // 
            btn_Sua.Location = new Point(190, 249);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(96, 36);
            btn_Sua.TabIndex = 3;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = true;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Location = new Point(292, 249);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(94, 36);
            btn_Xoa.TabIndex = 4;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            // 
            // btn_LamMoi
            // 
            btn_LamMoi.Location = new Point(392, 249);
            btn_LamMoi.Name = "btn_LamMoi";
            btn_LamMoi.Size = new Size(94, 36);
            btn_LamMoi.TabIndex = 5;
            btn_LamMoi.Text = "Làm mới";
            btn_LamMoi.UseVisualStyleBackColor = true;
            // 
            // dgv_ChiTieu
            // 
            dgv_ChiTieu.AllowUserToAddRows = false;
            dgv_ChiTieu.AllowUserToDeleteRows = false;
            dgv_ChiTieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ChiTieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ChiTieu.Location = new Point(12, 291);
            dgv_ChiTieu.MultiSelect = false;
            dgv_ChiTieu.Name = "dgv_ChiTieu";
            dgv_ChiTieu.ReadOnly = true;
            dgv_ChiTieu.RowHeadersWidth = 51;
            dgv_ChiTieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ChiTieu.Size = new Size(1201, 345);
            dgv_ChiTieu.TabIndex = 6;
            // 
            // lbl_TongChi
            // 
            lbl_TongChi.AutoSize = true;
            lbl_TongChi.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbl_TongChi.ForeColor = Color.Red;
            lbl_TongChi.Location = new Point(845, 645);
            lbl_TongChi.Name = "lbl_TongChi";
            lbl_TongChi.Size = new Size(183, 32);
            lbl_TongChi.TabIndex = 7;
            lbl_TongChi.Text = "Tổng chi: 0 ₫";
            // 
            // FormChiTieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1225, 685);
            Controls.Add(lbl_TongChi);
            Controls.Add(dgv_ChiTieu);
            Controls.Add(btn_LamMoi);
            Controls.Add(btn_Xoa);
            Controls.Add(btn_Sua);
            Controls.Add(btn_Them);
            Controls.Add(grBx_TimKiem);
            Controls.Add(grBx_ThongTinKhoanChi);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormChiTieu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sổ chi tiêu cá nhân";
            grBx_ThongTinKhoanChi.ResumeLayout(false);
            grBx_ThongTinKhoanChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDn_SoTien).EndInit();
            grBx_TimKiem.ResumeLayout(false);
            grBx_TimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ChiTieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grBx_ThongTinKhoanChi;
        private GroupBox grBx_TimKiem;
        private TextBox txt_GhiChu;
        private ComboBox cbo_LoaiChi;
        private TextBox txt_NoiDung;
        private DateTimePicker dtp_NgayChi;
        private Label lbl_GhiChu;
        private Label lbl_LoaiChi;
        private Label lbl_NoiDung;
        private Label lbl_NgayChi;
        private NumericUpDown numDn_SoTien;
        private Label lbl_SoTien;
        private DateTimePicker dtp_DenNgay;
        private DateTimePicker dtp_TuNgay;
        private Label lbl_DenNgay;
        private Label lbl_TuNgay;
        private ComboBox cbo_ChonLoaiChi;
        private Label lbl_NhapLoaiChi;
        private TextBox txt_NhapNoiDung;
        private Label lbl_NhapNoiDung;
        private Button btn_Tim;
        private Button btn_Them;
        private Button btn_Sua;
        private Button btn_Xoa;
        private Button btn_LamMoi;
        private DataGridView dgv_ChiTieu;
        private Label lbl_TongChi;
    }
}