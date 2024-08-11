using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Review_Project.MVVM.Model.MongoDB_Connect;

namespace Review_Project.MVVM.Model
{
    public class ValidationHandling
    {

        public enum TextValidate
        {
            Correct,
            NullOrEmpty
        }

        public static bool userLoginValidation(string username, string password) {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Yêu cầu nhập tài khoản và mật khẩu", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Question);
                    return false;
                }

                return true;
            }
            catch { 
                return false;
            }
        }

        public static TextValidate textValuesValidation(params string[] textValues) {

            foreach (string value in textValues) {
                if (string.IsNullOrEmpty(value))
                {
                    return TextValidate.NullOrEmpty;
                }
            }
            return TextValidate.Correct;
        }


        public static bool reviewerAccountValidation(REVIEWER_ACCOUNT account) {

            if(account == null)
            {
                MessageBox.Show("Tài khoản không tồn tại", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }


            if(account.USERNAME == "" || account.USERPASS == "" || account.PHONE == "" || account.GMAIL == "")
            {
                MessageBox.Show("Yêu cầu nhập dữ liệu đầy đủ", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (!IsGmailAddress(account.GMAIL))
            {
                MessageBox.Show("Email không hợp lệ", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }


            if (!IsPhoneNumber(account.PHONE))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            using(DB_SocialReviewDataContext db = new DB_SocialReviewDataContext())
            {
                REVIEWER_ACCOUNT reviewerSamePhone = db.REVIEWER_ACCOUNTs.Where(acc => acc.PHONE == account.PHONE).FirstOrDefault();

                if(reviewerSamePhone != null)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }


                REVIEWER_ACCOUNT reviewerSameUserName = db.REVIEWER_ACCOUNTs.Where(acc => acc.USERNAME == account.USERNAME).FirstOrDefault();

                if (reviewerSameUserName != null)
                {
                    MessageBox.Show("Username đã tồn tại", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }

                REVIEWER_ACCOUNT reviewerSamePass = db.REVIEWER_ACCOUNTs.Where(acc => acc.USERPASS == account.USERPASS).FirstOrDefault();

                if (reviewerSamePass != null)
                {
                    MessageBox.Show("Username đã tồn tại", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }

            }

            return true;
        }

        public static async Task<bool> reviewerUserValidation(Reviewer user) {
            
            ReviewerDBHandler db = new ReviewerDBHandler();
            Reviewer reviewer = await db.GetUserReviewerByNameAsync(user.Name);

            if (reviewer != null) {
                MessageBox.Show("Tên người dùng đã được sở hữu", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }


        public static bool IsGmailAddress(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }


        public static bool IsPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\d{10}$";

            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }


    }
}
