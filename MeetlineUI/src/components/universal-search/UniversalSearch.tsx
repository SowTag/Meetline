import React, { useEffect, useState } from 'react'
import { MailIcon, PhoneOutgoingIcon } from 'lucide-react'
import { Button } from '#/components/ui/button'
import {
  Command,
  CommandDialog,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList,
  CommandShortcut,
} from '#/components/ui/command'
import { Kbd } from '#/components/ui/kbd.tsx'
import { Avatar, AvatarImage } from '#/components/ui/avatar.tsx'
import { useUniversalSearch } from '#/components/universal-search/UniversalSearchProvider.tsx'

export function UniversalSearch() {
  const [_, setOpen] = useUniversalSearch()

  return (
    <>
      <Button
        variant="outline"
        className="h-8 w-full max-w-xs justify-start text-muted-foreground hidden md:flex"
        onClick={() => setOpen(true)}
      >
        <span className="inline-flex">Search all of Meetline...</span>
        <Kbd className="ml-auto">⌘ K</Kbd>
      </Button>
    </>
  )
}
