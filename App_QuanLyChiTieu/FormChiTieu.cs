using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Serilog;
using App_QuanLyChiTieu.Models; // Namespace Model scaffold ra

namespace App_QuanLyChiTieu
{
    public partial class FormChiTieu : Form
    {
        // Biến lưu mã đang chọn trên DataGridView (-1 nghĩa là chưa chọn)
        private int _selectedMaCT = -1;

        public FormChiTieu()
        {
            InitializeComponent();
            KhoiTaoGiaoDienVaDuLieu();
        }

        private void KhoiTaoGiaoDienVaDuLieu()
        {
            // 1. CẤU HÌNH CỘT CHO DATAGRIDVIEW BẰNG CODE (Chắc chắn không bị trắng ô)
            dgv_ChiTieu.AutoGenerateColumns = false;
            dgv_ChiTieu.Columns.Clear();

            dgv_ChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_MaCT",
                HeaderText = "Mã",
                DataPropertyName = "MaCt",
                FillWeight = 50
            });

            dgv_ChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_NgayChi",
                HeaderText = "Ngày chi",
                DataPropertyName = "NgayChi",
                FillWeight = 80
            });

            dgv_ChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_NoiDung",
                HeaderText = "Nội dung",
                DataPropertyName = "NoiDung",
                FillWeight = 150
            });

            dgv_ChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_LoaiChi",
                HeaderText = "Loại chi",
                DataPropertyName = "LoaiChi",
                FillWeight = 90
            });

            dgv_ChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_SoTien",
                HeaderText = "Số tiền",
                DataPropertyName = "SoTien",
                FillWeight = 90
            });

            dgv_ChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "col_GhiChu",
                HeaderText = "Ghi chú",
                DataPropertyName = "GhiChu",
                FillWeight = 120
            });

            // 2. CẤU HÌNH CHO NUMERIC (Bước nhảy 1.000, có phân cách hàng nghìn)
            numDn_SoTien.Minimum = 0;
            numDn_SoTien.Maximum = 1_000_000_000m;
            numDn_SoTien.Increment = 1000;
            numDn_SoTien.ThousandsSeparator = true;

            // 3. KHỞI TẠO DANH SÁCH LOẠI CHI CHO 2 COMBOBOX
            string[] danhSachLoaiChi = new[] { "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" };
            cbo_LoaiChi.Items.AddRange(danhSachLoaiChi);
            cbo_LoaiChi.SelectedIndex = 0;

            cbo_ChonLoaiChi.Items.Add("Tất cả");
            cbo_ChonLoaiChi.Items.AddRange(danhSachLoaiChi);
            cbo_ChonLoaiChi.SelectedIndex = 0;

            // 4. MẶC ĐỊNH NGÀY THÁNG
            DateTime now = DateTime.Today;
            dtp_TuNgay.Value = new DateTime(now.Year, now.Month, 1); // Đầu tháng hiện tại
            dtp_DenNgay.Value = now;
            dtp_NgayChi.Value = now;

            // 5. GẮN SỰ KIỆN (EVENTS)
            this.Load += async (s, e) => await TaiDuLieuAsync();
            dgv_ChiTieu.SelectionChanged += Dgv_ChiTieu_SelectionChanged;
            dgv_ChiTieu.CellFormatting += Dgv_ChiTieu_CellFormatting;

            btn_Them.Click += Btn_Them_Click;
            btn_Sua.Click += Btn_Sua_Click;
            btn_Xoa.Click += Btn_Xoa_Click;
            btn_LamMoi.Click += (s, e) => LamMoiForm();
            btn_Tim.Click += async (s, e) => await TaiDuLieuAsync();
        }

        // ĐỊNH DẠNG HIỂN THỊ CỘT TRÊN LƯỚI (Mã 001, Phân cách tiền 35.000, Ngày dd/MM/yyyy)
        private void Dgv_ChiTieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            // Format Mã: 1 -> 001
            if (dgv_ChiTieu.Columns[e.ColumnIndex].Name == "col_MaCT" && int.TryParse(e.Value.ToString(), out int ma))
            {
                e.Value = ma.ToString("D3");
                e.FormattingApplied = true;
            }
            // Format Tiền tệ: 35000 -> 35,000
            else if (dgv_ChiTieu.Columns[e.ColumnIndex].Name == "col_SoTien" && decimal.TryParse(e.Value.ToString(), out decimal tien))
            {
                e.Value = tien.ToString("N0");
                e.FormattingApplied = true;
            }
            // Format Ngày: dd/MM/yyyy
            else if (dgv_ChiTieu.Columns[e.ColumnIndex].Name == "col_NgayChi")
            {
                if (e.Value is DateOnly dOnly)
                {
                    e.Value = dOnly.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
                else if (e.Value is DateTime dt)
                {
                    e.Value = dt.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        // TẢI DỮ LIỆU KẾT HỢP TÌM KIẾM & LỌC LINQ (TASK 4)
        private async Task TaiDuLieuAsync()
        {
            try
            {
                using var context = new QL_ChiTieuContext();
                var query = context.ChiTieus.AsQueryable();

                // 1. Tìm theo nội dung
                string tuKhoa = txt_NhapNoiDung.Text.Trim();
                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(c => c.NoiDung.Contains(tuKhoa));
                }

                // 2. Lọc theo loại chi
                string loaiChi = cbo_ChonLoaiChi.SelectedItem?.ToString() ?? "Tất cả";
                if (loaiChi != "Tất cả")
                {
                    query = query.Where(c => c.LoaiChi == loaiChi);
                }

                // 3. Lọc theo khoảng ngày (Từ ngày -> Đến ngày)
                DateOnly tuNgay = DateOnly.FromDateTime(dtp_TuNgay.Value.Date);
                DateOnly denNgay = DateOnly.FromDateTime(dtp_DenNgay.Value.Date);
                query = query.Where(c => c.NgayChi >= tuNgay && c.NgayChi <= denNgay);

                // Sắp xếp ngày giảm dần
                var danhSach = await query.OrderByDescending(c => c.NgayChi)
                                          .ThenByDescending(c => c.MaCt)
                                          .ToListAsync();

                dgv_ChiTieu.DataSource = danhSach;

                // Tự động tính và cập nhật tổng tiền
                decimal tongTien = danhSach.Sum(c => c.SoTien);
                lbl_TongChi.Text = $"Tổng chi: {tongTien:N0} ₫";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi tải hoặc lọc dữ liệu chi tiêu từ CSDL");
                MessageBox.Show("Không thể tải dữ liệu từ CSDL! Vui lòng kiểm tra kết nối.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ĐỔ DỮ LIỆU KHI CHỌN DÒNG TRÊN LƯỚI
        private void Dgv_ChiTieu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ChiTieu.CurrentRow != null && dgv_ChiTieu.CurrentRow.DataBoundItem is ChiTieu ct)
            {
                _selectedMaCT = ct.MaCt;
                txt_NoiDung.Text = ct.NoiDung;
                numDn_SoTien.Value = ct.SoTien;
                cbo_LoaiChi.SelectedItem = ct.LoaiChi;
                txt_GhiChu.Text = ct.GhiChu ?? string.Empty;
                dtp_NgayChi.Value = ct.NgayChi.ToDateTime(TimeOnly.MinValue);
            }
        }

        // KIỂM TRA HỢP LỆ (TASK 3)
        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txt_NoiDung.Text))
            {
                MessageBox.Show("Nội dung chi tiêu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NoiDung.Focus();
                return false;
            }

            if (numDn_SoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền chi phải lớn hơn 0 ₫!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDn_SoTien.Focus();
                return false;
            }

            if (dtp_NgayChi.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày chi không được lớn hơn ngày hôm nay!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_NgayChi.Focus();
                return false;
            }

            return true;
        }

        // 1. THÊM KHOẢN CHI (TASK 3 & TASK 6)
        private async void Btn_Them_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            try
            {
                using var context = new QL_ChiTieuContext();
                var chiTieu = new ChiTieu
                {
                    NgayChi = DateOnly.FromDateTime(dtp_NgayChi.Value.Date),
                    NoiDung = txt_NoiDung.Text.Trim(),
                    LoaiChi = cbo_LoaiChi.SelectedItem?.ToString() ?? "Khác",
                    SoTien = numDn_SoTien.Value,
                    GhiChu = string.IsNullOrWhiteSpace(txt_GhiChu.Text) ? null : txt_GhiChu.Text.Trim()
                };

                context.ChiTieus.Add(chiTieu);
                await context.SaveChangesAsync();

                // Ghi log Serilog mức Information kèm MaCT
                Log.Information("Thêm khoản chi thành công: MaCT={MaCT}, Số tiền={SoTien}, Loại={LoaiChi}", chiTieu.MaCt, chiTieu.SoTien, chiTieu.LoaiChi);

                MessageBox.Show("Thêm mới khoản chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDuLieuAsync();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi thêm khoản chi tiêu");
                MessageBox.Show("Đã xảy ra lỗi khi lưu vào CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. SỬA KHOẢN CHI (TASK 3 & TASK 6)
        private async void Btn_Sua_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng chi tiêu trên bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!KiemTraHopLe()) return;

            try
            {
                using var context = new QL_ChiTieuContext();
                var chiTieu = await context.ChiTieus.FindAsync(_selectedMaCT);
                if (chiTieu == null)
                {
                    MessageBox.Show("Bản ghi chi tiêu không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                chiTieu.NgayChi = DateOnly.FromDateTime(dtp_NgayChi.Value.Date);
                chiTieu.NoiDung = txt_NoiDung.Text.Trim();
                chiTieu.LoaiChi = cbo_LoaiChi.SelectedItem?.ToString() ?? "Khác";
                chiTieu.SoTien = numDn_SoTien.Value;
                chiTieu.GhiChu = string.IsNullOrWhiteSpace(txt_GhiChu.Text) ? null : txt_GhiChu.Text.Trim();

                await context.SaveChangesAsync();

                // Ghi log Serilog mức Information
                Log.Information("Cập nhật khoản chi thành công: MaCT={MaCT}", _selectedMaCT);

                MessageBox.Show("Cập nhật khoản chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDuLieuAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi cập nhật khoản chi MaCT={MaCT}", _selectedMaCT);
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật vào CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. XÓA KHOẢN CHI (CÓ HỎI XÁC NHẬN - TASK 3 & TASK 6)
        private async void Btn_Xoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng chi tiêu trên bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khoản chi [Mã: {_selectedMaCT:D3}] - \"{txt_NoiDung.Text}\"?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using var context = new QL_ChiTieuContext();
                    var chiTieu = await context.ChiTieus.FindAsync(_selectedMaCT);
                    if (chiTieu != null)
                    {
                        context.ChiTieus.Remove(chiTieu);
                        await context.SaveChangesAsync();

                        // Ghi log Serilog mức Information
                        Log.Information("Xóa khoản chi thành công: MaCT={MaCT}", _selectedMaCT);

                        MessageBox.Show("Xóa khoản chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await TaiDuLieuAsync();
                        LamMoiForm();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Lỗi xảy ra khi xóa khoản chi MaCT={MaCT}", _selectedMaCT);
                    MessageBox.Show("Đã xảy ra lỗi khi xóa khỏi CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 4. LÀM MỚI FORM
        private void LamMoiForm()
        {
            _selectedMaCT = -1;
            txt_NoiDung.Clear();
            numDn_SoTien.Value = 0;
            cbo_LoaiChi.SelectedIndex = 0;
            txt_GhiChu.Clear();
            dtp_NgayChi.Value = DateTime.Today;

            dgv_ChiTieu.ClearSelection();
            txt_NoiDung.Focus();
        }
    }
}