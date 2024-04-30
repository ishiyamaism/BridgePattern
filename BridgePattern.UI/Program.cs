using BridgePattern.Exeptions;
using BridgePattern.Infrastructure.Devices;
using BridgePattern.Infrastructure.Measures;
using BridgePattern.UI.States;

namespace BridgePattern.UI;

class Program
{
    static private StateMachine _stateMachine = new StateMachine();
    static private string? _currentState;

    private static Device _device;

    static Program()
    {
        _stateMachine.StateChanged += StateMachine_StateChanged;

        // 初期センサー
        IMeasure measure = new TemperatureMeasure();
        _device = new ACDevice(measure);
    }


    private static string NameLabelText = "empty";
    private static string MeasureLabelText = "empty";
    private static string SensitivityLabelText = "empty";
    private static string BatteryLabelText = "empty";

    private static void DisplayLabels()
    {
        Console.WriteLine(NameLabelText);
        Console.WriteLine(MeasureLabelText);
        Console.WriteLine(SensitivityLabelText);
        Console.WriteLine(BatteryLabelText);
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Press Enter to display device infomation");
        Console.WriteLine("Press → to change status mode,");
        Console.WriteLine("and the other Keys for Input Trigger. Esc to exit.");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);  // trueでキーのエコーをオフにする
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("bye.");
                break;
            }
            // Escキーでループを抜けてプログラムを終了

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("...Get data...");

                    try
                    {
                        NameLabelText = _device.GetName() + _device.GetDeviceName();
                        MeasureLabelText = _device.GetMeasure();
                        SensitivityLabelText = _device.GetSensitivity();
                        BatteryLabelText = _device.GetBatteryLevel();

                    }
                    catch (InputDataException ex)
                    {
                        if (ex.Kind == ExceptionBase.ExceptionKind.Error)
                        {
                            Console.WriteLine("致命的エラーです");
                            throw new FileNotFoundException();

                        }
                        else if (ex.Kind == ExceptionBase.ExceptionKind.Info)
                        {
                            Console.WriteLine("情報レベルのエラーです");
                        }
                    }

                    DisplayLabels();

                    break;
                case ConsoleKey.A:
                    Console.WriteLine("Press: A");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("Press: →");

                    // 測定モードチェンジ
                    _stateMachine.Update();
                    break;
                case ConsoleKey.D0:
                    Console.WriteLine("Press: 0");
                    break;
                case ConsoleKey.D1:
                    Console.WriteLine("Press: 1");
                    break;

                default:
                    break;
            }
        }
    }

    static private void StateMachine_StateChanged()
    {
        // State変更時の処理を実装
        _currentState = _stateMachine.GetText();
        Console.WriteLine(_currentState);

        _device = _stateMachine.GetDevice();
    }
}
