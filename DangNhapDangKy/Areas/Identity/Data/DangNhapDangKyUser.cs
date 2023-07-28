using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DangNhapDangKy.Areas.Identity.Data;

// Add profile data for application users by adding properties to the DangNhapDangKyUser class
public class DangNhapDangKyUser : IdentityUser
{
  // Mã hóa dữ liệu cá nhân khi lưu trữ dữ liệu hoặc khi truyền dữ liệu
  [PersonalData]
  // Kiểu dữ liệu nvarchar tối đa 200 ký tự
  [Column(TypeName = "nvarchar(200)")]
  // trường Tên
  public string FirstName { get; set; }
  
  // trường Họ
  [PersonalData]
  [Column(TypeName = "nvarchar(200)")]
  public string LastName { get; set; }
}

