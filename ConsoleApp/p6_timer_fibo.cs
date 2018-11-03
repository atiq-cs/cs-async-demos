// Copyright (c) FFTSys Inc. All rights reserved.
// Use of this source code is governed by a GPL-v3 license

namespace AsyncDemos {
  using System;
  using System.Threading.Tasks;

  /// <summary>
  /// Run timer concurrently with main thread without blocking
  /// If we want to run all code of the main thread and background task concurrently then we can
  /// put await at the end of main thread. Example,
  /// 
  /// <c>mathWork.fibo();
  /// Console.WriteLine("main terminates");
  /// await timerToFinish;</c>
  /// Part of artilce: https://atiqcs.wordpress.com/2018/08/18/csharp-async-programming/
  /// </summary>
  class p6TimerAsyncNonblocking {
    static async Task Main(string[] args) {
      Timer tDemo = new Timer();
      Task timerToFinish = Task.Run(() => tDemo.Run());
      // at this point, runs fibo and timer concurrently
      MathCompute mathWork = new MathCompute();
      mathWork.fibo();
      // now let's wait till timer finishes
      await timerToFinish;
      // assuming we might need some result from timerToFinish from here, otherwise we can do more
      // work and then 'await'
      Console.WriteLine("main terminates");
    }
  }

  class Timer {
    public async Task Run() {
      Console.WriteLine("Timer starting..");
      const int timeLimit = 5;
      for (int i = 0; i < timeLimit; i++) {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.Write("\rtime passed " + (i + 1) + "s");
      }
      Console.WriteLine();
    }
  }

  class MathCompute {
    public void fibo() {
      Console.WriteLine("A few fibo nums below,");
      int n = 10;
      int a = 0, b = 1, c = 0;
      for (int i = 1; i < n; i++) {
        c = a + b;
        Console.WriteLine(c);
        a = b;
        b = c;
      }
    }
  }
}
