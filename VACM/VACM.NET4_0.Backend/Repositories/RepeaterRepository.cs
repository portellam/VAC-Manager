using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using VACM.NET4_0.Backend.Models;

namespace VACM.NET4_0.Backend.Repositories
{
  public class RepeaterRepository :
    INotifyPropertyChanged,
    IRepeaterRepository
  {
    #region Parameters

    /// <summary>
    /// The collection of repeaters.
    /// </summary>
    private HashSet<RepeaterModel> RepeaterModelHashSet;

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Logic

    /// <summary>
    /// Constructor
    /// </summary>
    [ExcludeFromCodeCoverage]
    public RepeaterRepository()
    {
      RepeaterModelHashSet = new HashSet<RepeaterModel>();
    }

    /// <summary>
    /// Remove a repeater.
    /// </summary>
    /// <param name="id">The repeater ID</param>
    /// <returns>True/false remove a repeater if the repeater exists.</returns>
    private bool Remove(uint id)
    {
      RepeaterModel repeaterModel = Get(id);

      if (repeaterModel is null)
      {
        return false;
      }

      return RepeaterModelHashSet
        .RemoveWhere
        (x => x.Id == repeaterModel.Id) > 0;
    }

    /// <summary>
    /// Logs event when property has changed.
    /// </summary>
    /// <param name="propertyName">The property name</param>
    private void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke
      (
        this,
        new PropertyChangedEventArgs(propertyName)
      );
    }

    /// <summary>
    /// Get repeater by ID.
    /// </summary>
    /// <param name="id">the repeater ID</param>
    /// <returns>The repeater.</returns>
    public RepeaterModel Get(uint? id)
    {
      if (
        id is null
        || id < 0
      )
      {
        return null;
      }

      return RepeaterModelHashSet
        .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Get repeater by ID.
    /// </summary>
    /// <param name="firstDeviceId">The first device ID</param>
    /// <param name="secondDeviceId">The second device ID</param>
    /// <returns>The repeater.</returns>
    public RepeaterModel Get
    (
      uint? firstDeviceId,
      uint? secondDeviceId
    )
    {
      if
      (
        firstDeviceId is null
        && secondDeviceId is null
      )
      {
        return null;
      }

      return RepeaterModelHashSet
        .FirstOrDefault
        (
          x =>
          (
            x.InputDeviceId == firstDeviceId
            && x.OutputDeviceId == secondDeviceId
          ) || (
            x.InputDeviceId == secondDeviceId
            && x.OutputDeviceId == firstDeviceId
          )
        );
    }

    /// <summary>
    /// Get repeater by input device name.
    /// </summary>
    /// <param name="name">the input device name</param>
    /// <returns>The repeater of the input.</returns>
    public RepeaterModel GetRepeaterByInputName(string name)
    {
      if (
        RepeaterModelHashSet is null
          || name is null
          || name == string.Empty
      )
      {
        return null;
      }

      return RepeaterModelHashSet
        .FirstOrDefault(x => x.InputDeviceName == name);
    }

    /// <summary>
    /// Get repeater by output device name.
    /// </summary>
    /// <param name="name">the output device name</param>
    /// <returns>The repeater of the output.</returns>
    public RepeaterModel GetRepeaterByOutputName(string name)
    {
      if (
        RepeaterModelHashSet is null
          || name is null
          || name == string.Empty
      )
      {
        return null;
      }

      return RepeaterModelHashSet
        .FirstOrDefault(x => x.OutputDeviceName == name);
    }

    /// <summary>
    /// Get repeater list.
    /// </summary>
    /// <returns>The repeater list.</returns>
    public List<RepeaterModel> GetAll()
    {
      if (RepeaterModelHashSet is null)
      {
        return new List<RepeaterModel>();
      }

      return
        RepeaterModelHashSet
          .ToList();
    }

    /// <summary>
    /// Get a list of repeaters.
    /// </summary>
    /// <param name="idList">the repeater ID list</param>
    /// <returns>A list of repeaters.</returns>
    public List<RepeaterModel> GetRange(List<uint?> idList)
    {
      if
      (
        idList is null
        || idList.Count == 0
        || RepeaterModelHashSet is null
        || RepeaterModelHashSet.Count == 0
      )
      {
        return null;
      }

      List<RepeaterModel> repeaterList = new List<RepeaterModel>();

      idList
        .ForEach
        (
          id =>
          repeaterList
            .Add(Get(id))
        );

      return repeaterList;
    }

    /// <summary>
    /// Add a repeater.
    /// </summary>
    /// <param name="repeaterModel">The repeater</param>
    public void Insert(RepeaterModel repeaterModel)
    {
      if (repeaterModel is null)
      {
        return;
      }

      if (RepeaterModelHashSet.Count() >= Global.MaxRepeaterCount)
      {
        Console.WriteLine
          (
            string.Format
            (
              "Cancelled repeater addition. " +
              "Repeater list amount will exceed maximum amount of {1}.",
              Global.MaxRepeaterCount
            )
          );

        return;
      }


      RepeaterModelHashSet.Add(repeaterModel);
    }

    /// <summary>
    /// Remove a repeater.
    /// </summary>
    /// <param name="id">The repeater ID</param>
    public void Remove(uint? id)
    {
      if (id is null)
      {
        return;
      }

      bool isSuccess = Remove((uint)id);
    }

    /// <summary>
    /// Remove a repeater.
    /// </summary>
    /// <param name="firstDeviceId">The first device ID</param>
    /// <param name="secondDeviceId">The second device ID</param>
    public void Remove
    (
      uint? firstDeviceId,
      uint? secondDeviceId
    )
    {
      RepeaterModel repeaterModel =
        Get
        (
          firstDeviceId,
          secondDeviceId
        );

      if (repeaterModel is null)
      {
        return;
      }

      Remove(repeaterModel.Id);
    }

    /// <summary>
    /// Update a repeater.
    /// </summary>
    /// <param name="repeaterModel">The repeater to update.</param>
    public void Update(RepeaterModel repeaterModel)
    {
      if (repeaterModel is null)
      {
        return;
      }

      if
      (
        RepeaterModelHashSet
          .RemoveWhere
          (x => x.Id == repeaterModel.Id) == 0
      )
      {
        return;
      }

      RepeaterModelHashSet
        .Add(repeaterModel);
    }

    /// <summary>
    /// Update a repeater.
    /// </summary>
    /// <param name="id">The repeater ID</param>
    /// <param name="inputDeviceId">The input device ID</param>
    /// <param name="outputDeviceId">The output device ID</param>
    /// <param name="bitsPerSample">The amount of bits per sample</param>
    /// <param name="bufferAmount">The buffer amount</param>
    /// <param name="bufferDurationMs">The buffer duration in milliseconds</param>
    /// <param name="channelList">The channel list</param>
    /// <param name="channelMask">The channel mask</param>
    /// <param name="pathName">The path name</param>
    /// <param name="prefillPercentage">The prefill percentage</param>
    /// <param name="propertyList">The property list</param>
    /// <param name="resyncAtPercentage">The resync at percentage</param>
    /// <param name="sampleRateKHz">The sample rate in KiloHertz</param>
    /// <param name="windowName">The window name</param>
    public void Update
    (
      uint id,
      uint inputDeviceId,
      uint outputDeviceId,
      byte bitsPerSample,
      byte bufferAmount,
      byte prefillPercentage,
      byte resyncAtPercentage,
      string inputDeviceName,
      string outputDeviceName,
      string pathName,
      string windowName,
      uint channelMask,
      uint sampleRateKHz,
      ushort bufferDurationMs
    )
    {
      RepeaterModel repeaterModel = new RepeaterModel
      (
        id,
        inputDeviceId,
        outputDeviceId
      )
      {
        BitsPerSample = bitsPerSample,
        BufferAmount = bufferAmount,
        PrefillPercentage = prefillPercentage,
        ResyncAtPercentage = resyncAtPercentage,
        InputDeviceName = inputDeviceName,
        OutputDeviceName = outputDeviceName,
        PathName = pathName,
        WindowName = windowName,
        ChannelMask = channelMask,
        SampleRateKHz = sampleRateKHz,
        BufferDurationMs = bufferDurationMs
      };

      Update(repeaterModel);
    }

    #endregion
  }
}