// Copyright (c) FFTSys Inc. All rights reserved.
// Use of this source code is governed by a GPL-v3 license

namespace AsyncDemos {
  using System;
  using System.Threading.Tasks;

  /// <summary>
  /// Main Method Async
  /// await done right
  /// Part of artilce: https://atiqcs.wordpress.com/2018/08/18/csharp-async-programming/
  /// </summary>
  class p4AsyncMain {
    static async Task Main(string[] args) {
      ThreadingTest demo = new ThreadingTest();
      await demo.Run();
      Console.WriteLine("Main terminates");
    }
  }

  class ThreadingTest {
    public async Task Run() {
      Console.WriteLine("my current thread");
      var asyncStr = await Task.Run(() => MyFoo());
      Console.WriteLine("my synchronous method..");
      Console.WriteLine("thread result: " + asyncStr);
    }

    public async Task<string> MyFoo() {
      Console.WriteLine("my new thread.");
      await Task.Delay(1000);
      Console.WriteLine("new thread finished.");
      return "f00";
    }
  }
}

/* Example output,
my current thread
my new thread.
new thread finished.
my synchronous method..
thread result: f00
Main terminates
*/
