using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace LecturaDataFrames
{
    class Program
    {
        static SerialPort _serial;
        public const int FRAME_WIDTH = 128;
        private static Queue<byte[]> _dataFrameBuffer = new Queue<byte[]>();

        static void Main(string[] args)
        {
            _serial = new SerialPort("COM10", 19200, Parity.None, 8, StopBits.One);
            _serial.DataReceived += new SerialDataReceivedEventHandler(DataRecieved);
            _serial.ReceivedBytesThreshold = 2 * (FRAME_WIDTH + 1); //El +1 corresponde al byte de cabecera
            _serial.ReadTimeout = 1000;
            _serial.Open();
            _serial.Write("f");

            Console.WriteLine("Esperando datos...");
            Console.ReadKey();
            _serial.Close();
        }


        private static void DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {

            while (_serial.BytesToRead >= FRAME_WIDTH)
            {
                byte[] frameBuffer = new byte[FRAME_WIDTH];
                if (_serial.ReadByte() == 255) _serial.Read(frameBuffer, 0, FRAME_WIDTH - 1);
                _dataFrameBuffer.Enqueue(frameBuffer);
            }

            while (_dataFrameBuffer.Count != 0)
            {
                byte[] dataFrame = _dataFrameBuffer.Dequeue();
                Console.WriteLine($"Dato ({dataFrame.Length}) : {System.Text.Encoding.Default.GetString(dataFrame)}");
            }
        }


    }
}
