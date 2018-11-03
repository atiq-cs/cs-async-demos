// Copyright (c) FFTSys Inc. All rights reserved.
// Use of this source code is governed by a GPL-v3 license

namespace AsyncDemos {
  using System;
  using System.Threading.Tasks;

  /// <summary>
  /// Synchronous Thread: demonstrating synchronous flow of the methods
  /// Exampe run is at bottom
  /// 
  /// Part of artilce: https://atiqcs.wordpress.com/2018/08/18/csharp-async-programming/
  /// </summary>
  class p2ASyncVoid {
    static void Main(string[] args) {
      ThreadingTest demo = new ThreadingTest();
      Console.WriteLine("Before running my foo()");
      demo.Run();
      Console.WriteLine("After running my foo()");
      Task.Delay(2000);
    }
  }

  class ThreadingTest {
    /* Bad *** redflag - beginner's mistake or not async void but always Task */
    public async void Run() {
      var asyncStr = await Task.Run(() => MyFooAsync());
      Console.WriteLine("my non async str: " + "casually sugar rush candy!!");
      Console.WriteLine("async result: " + asyncStr);
    }

    public async Task<string> MyFooAsync() {
      await Task.Delay(1000);
      return "f00";
    }
  }
}
