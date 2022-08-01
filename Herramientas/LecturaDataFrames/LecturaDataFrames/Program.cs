using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace LecturaDataFrames
{
    class Program
    {
        static SerialPort _serial;
        //public const int FRAME_WIDTH = 128;
        public const int FRAME_WIDTH = 1024; //2048;
        private static Queue<byte[]> _dataFrameBuffer = new Queue<byte[]>();

        static void Main(string[] args)
        {
            _serial = new SerialPort("COM15", 921600, Parity.None, 8, StopBits.One);
            _serial.DataReceived += new SerialDataReceivedEventHandler(DataRecieved);
            _serial.ReceivedBytesThreshold =(FRAME_WIDTH + 1); //El +1 corresponde al byte de cabecera
                                                                        //El 4 corresponde a que cada muestra esta compuesta de 4 bytes
            _serial.ReadTimeout = 1000;
            _serial.Open();
            //_serial.Write("f");

            //Console.WriteLine("Esperando datos...");
            Console.ReadKey();
            //_serial.Close();


            int[] planets = { 1,2,3,4,56 };

            //bool result = !Array.Exists(planets, element => element == 56);
            //Console.WriteLine(result);

        }


        private static void DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            uint valor = 0;
            Stopwatch sw = new Stopwatch();
            List<uint> frame = new List<uint>(2047);

            while (_serial.BytesToRead >= 4 * FRAME_WIDTH)
            {
                byte[] frameBuffer = new byte[4 * FRAME_WIDTH];

                if (_serial.ReadByte() == 255)
                {
                    sw.Start();
                    _serial.Read(frameBuffer, 0, 4 * FRAME_WIDTH);
                    for (int i = 0; i < 4 * FRAME_WIDTH; i += 4)
                    {
                        valor = (uint)frameBuffer[i] + (uint)(frameBuffer[i + 1] << 8) + (uint)(frameBuffer[i + 2] << 16) + (uint)(frameBuffer[i + 3] << 24);
                        frame.Add(valor);
                    }
                    sw.Stop();
                    Console.WriteLine($"Valores leido en {sw.ElapsedMilliseconds} ms");
                    for (int i = 0; i < FRAME_WIDTH; i++)
                        Console.WriteLine($"Valor {i}: {frame[i]}");
                }
            }
        }



            //private static void DataRecieved(object sender, SerialDataReceivedEventArgs e)
            //{
            //    uint valor = 0;
            //    Stopwatch sw = new Stopwatch();
            //    List<uint> frame = new List<uint>(2047);

            //    while (_serial.BytesToRead >= 4 * FRAME_WIDTH)
            //    {
            //        byte[] frameBuffer = new byte[4 * FRAME_WIDTH];
            //        byte[] intBuffer = new byte[4];

            //        if (_serial.ReadByte() == 255)
            //        {
            //            sw.Start();
            //            for (int i = 0; i < FRAME_WIDTH; i++)
            //            {
            //                _serial.Read(intBuffer, 0, 4);
            //                valor = (uint)intBuffer[0] + (uint)(intBuffer[1] << 8) + (uint)(intBuffer[2] << 16) + (uint)(intBuffer[3] << 24);
            //                frame.Add(valor);
            //            }
            //            sw.Stop();

            //            Console.WriteLine($"Valores leido en {sw.ElapsedMilliseconds} ms");
            //            for (int i = 0; i < FRAME_WIDTH; i++)
            //                Console.WriteLine($"Valor {i}: {frame[i]}");
            //        }

            //        //_dataFrameBuffer.Enqueue(frameBuffer);
            //    }


            //            for (int i = 0; i < (4 * FRAME_WIDTH); i += 4)
            //          {
            //            _serial.Re
            //      }
            //}


            //private static void DataRecieved(object sender, SerialDataReceivedEventArgs e)
            //{

            //    while (_serial.BytesToRead >= FRAME_WIDTH)
            //    {
            //        byte[] frameBuffer = new byte[FRAME_WIDTH];

            //        if (_serial.ReadByte() == 255)
            //        {
            //            _serial.Read(frameBuffer, 0, (4 * FRAME_WIDTH) - 1);
            //        }
            //        _dataFrameBuffer.Enqueue(frameBuffer);
            //    }

            //    while (_dataFrameBuffer.Count != 0)
            //    {
            //        byte[] dataFrame = _dataFrameBuffer.Dequeue();
            //        Console.WriteLine($"Dato ({dataFrame.Length}) : {System.Text.Encoding.Default.GetString(dataFrame)}");
            //    }
            //}


        }
}
