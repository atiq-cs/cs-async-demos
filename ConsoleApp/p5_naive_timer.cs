// Copyright (c) FFTSys Inc. All rights reserved.
// Use of this source code is governed by a GPL-v3 license

namespace AsyncDemos {
  using System;
  using System.Threading.Tasks;

  /// <summary>
  /// Implement timer using async delay
  /// This naive timer deos not create a new task and blocks main thread
  /// Part of artilce: https://atiqcs.wordpress.com/2018/08/18/csharp-async-programming/
  /// </summary>
  class p5TimerUsingAsyncMethod {
    static async Task Main(string[] args) {
      Timer demo = new Timer();
      await demo.Run();
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
}
