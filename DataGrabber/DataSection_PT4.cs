using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace DataGrabber
{
    /// <summary>
    // Представляет из себя одну секцию тестов.
    /// </summary>
    public class DataSection_PT4 : IEnumerable<KeyValuePair<string, double>>
    {
        public double Rx;
        public double dR;
        public double Qa;
        public double dl;
        public double PPCu;
        public double rk;
        public double Umin1;
        public double Umin3;

        /// <summary>
        /// Пытается создать новую секцию из текста.
        /// </summary>
        /// <exception cref="ArgumentException">Если переданный параметр не удалось преобразовать в double</exception>
        /// <returns></returns>
        public static DataSection_PT4 Create(string rx, string dR, string qa, string dl, string ppCu, string rk,
            string umin1, string umin3)
        {
            if (!double.TryParse(rx, out var RX))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(rx));
            }
            if (!double.TryParse(dR, out var DR))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(dR));
            }
            if (!double.TryParse(qa, out var QA))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(qa));
            }
            if (!double.TryParse(dl, out var DL))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(dl));
            }
            if (!double.TryParse(ppCu, out var PPCU))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(ppCu));
            }
            if (!double.TryParse(rk, out var RK))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(rk));
            }
            if (!double.TryParse(umin1, out var UMIN1))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(umin1));
            }
            if (!double.TryParse(umin3, out var UMIN3))
            {
                throw new ArgumentException("Can't parse string to double!", nameof(umin3));
            }

            return new DataSection_PT4
            {
                dl = DL,
                dR = DR,
                PPCu = PPCU,
                Qa = QA,
                rk = RK,
                Rx = RX,
                Umin1 = UMIN1,
                Umin3 = UMIN3
            };
        }

        public IEnumerator<KeyValuePair<string, double>> GetEnumerator()
        {
            var fields = typeof(DataSection_PT4).GetFields();
            foreach (var field in fields)
            {
                yield return new KeyValuePair<string, double>(field.Name, (double)field.GetValue(this));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
